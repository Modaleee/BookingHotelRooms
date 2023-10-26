using BookingHotelRooms.Models;
using BookingHotelRooms.Models.ViewModels;
using BookingHotelRooms.Repositories;
using BookingHotelRooms.Repositories.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingHotelRooms.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IRoomRepository _roomRepository;

        public BookingController(IBookingRepository bookingRepository, IRoomRepository roomRepository)
        {
            _bookingRepository = bookingRepository;
            _roomRepository = roomRepository;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetBookings()
        {
            var bookings = await _bookingRepository.GetAllBookings();
            var model= bookings.OrderByDescending(x => x.OrderDate).GroupBy(x => x.ApplicationUser.UserName); ;

            if (!HttpContext.User.IsInRole("Admin"))
            {
                var user = await _bookingRepository.GetContextUser(HttpContext);
                model = bookings.Where(x => x.AppUserId == user.Id).OrderByDescending(x => x.OrderDate).GroupBy(x => x.ApplicationUser.UserName);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> BookRoom(int roomId)
        {
            var room = await _roomRepository.GetRoom(roomId);
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

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> BookRoom(BookingDetailsViewModel booking)
        {
            var days = (booking.CheckOut - booking.CheckIn).Days;
            if (days < 1)
            {
                ModelState.AddModelError("Days", "You should book at least one day to proceed!");
            }

            if (ModelState.IsValid)
            {
                var room = await _roomRepository.GetRoom(booking.RoomId);
                var user = await _bookingRepository.GetContextUser(HttpContext);

                var model = new Booking
                {
                    Room = room,
                    RoomId = booking.RoomId,
                    BookingId = Guid.NewGuid().ToString(),
                    CheckIn = booking.CheckIn,
                    CheckOut = booking.CheckOut,
                    OrderDate = DateTime.Now,
                    TotalPrice = days * room.Price,
                    ApplicationUser = user,
                    AppUserId = user.Id,
                    BookingStatus = Status.Draft
                };
                await _bookingRepository.CreateBooking(model);

                return RedirectToAction("BookingResult", "Booking", new { bookingId = model.BookingId });
            }

            return View(booking);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> BookingResult(string bookingId)
        {
            var booking = await _bookingRepository.GetBooking(bookingId);

            var model = new BookingResultViewModel
            {
                BookingId= bookingId,
                RoomNumber = booking.Room.RoomNumber,
                CheckIn = booking.CheckIn,
                CheckOut = booking.CheckOut,
                TotalPrice = booking.TotalPrice
            };

            return View(model);

        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> FinishBooking(BookingResultViewModel bookingResult)
        {
            var booking = await _bookingRepository.GetBooking(bookingResult.BookingId);
            booking.BookingStatus = Status.Completed;

            await _bookingRepository.UpdateBookingUser(booking);
            await _roomRepository.ChangeRoomAvailability(booking.RoomId);

            return RedirectToAction("Index", "Rooms");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CancelBooking(string bookingId)
        {
            await _bookingRepository.DeleteBooking(bookingId);

            return RedirectToAction("Index", "Rooms");
        }
    }
}
