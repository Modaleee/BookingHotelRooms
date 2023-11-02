using BookingHotelRooms.Models;
using BookingHotelRooms.Models.ViewModels;
using BookingHotelRooms.Repositories;
using BookingHotelRooms.Repositories.IRepository;
using BookingHotelRooms.Services.IServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingHotelRooms.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IRoomRepository _roomRepository;

        public BookingService(IBookingRepository bookingRepository, IRoomRepository roomRepository)
        {
            _bookingRepository = bookingRepository;
            _roomRepository = roomRepository;
        }


        public async Task<Booking> FindBookingAsync(string id)
        {
            return await _bookingRepository.GetBookingById(id);
        }

        public async Task<IEnumerable<IGrouping<string, Booking>>> GetAllBookingsAsync(HttpContext httpContext)
        {

            var bookings = await _bookingRepository.GetAllBookings();
            var model = bookings.OrderByDescending(x => x.OrderDate).GroupBy(x => x.ApplicationUser.UserName); ;

            if (!httpContext.User.IsInRole("Admin"))
            {
                var user = await GetContextUserAsync(httpContext);
                model = bookings.Where(x => x.AppUserId == user.Id).OrderByDescending(x => x.OrderDate).GroupBy(x => x.ApplicationUser.UserName);
            }
            return model;
        }

        public async Task<AppUser> GetContextUserAsync(HttpContext httpContext)
        {
            var user = httpContext.User.Identity.Name;

            return await _bookingRepository.GettUserByName(user);
        }

        public async Task AddBookingAsync(BookingDetailsViewModel booking, HttpContext context, string id)
        {
            var room = await _roomRepository.GetRoomById(booking.RoomId);
            var days = (booking.CheckOut - booking.CheckIn).Days;
            var user = await GetContextUserAsync(context);

            var model = new Booking
            {
                Room = room,
                RoomId = booking.RoomId,
                BookingId = id,
                CheckIn = booking.CheckIn,
                CheckOut = booking.CheckOut,
                OrderDate = DateTime.Now,
                TotalPrice = days * room.Price,
                ApplicationUser = user,
                AppUserId = user.Id,
                BookingStatus = Status.Draft
            };
            await _bookingRepository.CreateBooking(model);
        }

        public async Task UpdateBookingAsync(BookingResultViewModel bookingResult)
        {
            var booking = await FindBookingAsync(bookingResult.BookingId);
            booking.BookingStatus = Status.Completed;

            await _bookingRepository.UpdateBooking(booking);
            await ChangeRoomAvailabilityAsync(booking.RoomId);
        }


        public async Task RemoveBookingAsync(string id)
        {
            await  _bookingRepository.DeleteBooking(id);
        }

        public async Task<BookingResultViewModel> BookingResultAsync(string bookingId)
        {
            var booking = await FindBookingAsync(bookingId);

            var model = new BookingResultViewModel
            {
                BookingId = bookingId,
                RoomNumber = booking.Room.RoomNumber,
                CheckIn = booking.CheckIn,
                CheckOut = booking.CheckOut,
                TotalPrice = booking.TotalPrice
            };
            return model;
        }

        public async Task<BookingDetailsViewModel> BookRoomAsync(int roomId)
        {
            var room = await _roomRepository.GetRoomById(roomId);
            var model = new BookingDetailsViewModel
            {
                RoomId = room.RoomId,
                RoomNumber = room.RoomNumber,
                IsAvailable = room.IsAvailable,
                Description = room.Description,
                Price = room.Price,
                CheckIn = DateTime.Today,
                CheckOut = DateTime.Today,
            };
            return model;
        }

        public async Task ChangeRoomAvailabilityAsync(int roomId)
        {
            var room = await _roomRepository.GetRoomById(roomId);

            room.IsAvailable = false;
            await _roomRepository.UpdateRoom(room);
        }
    }
}
