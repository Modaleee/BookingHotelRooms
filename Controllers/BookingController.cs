using BookingHotelRooms.Models;
using BookingHotelRooms.Models.ViewModels;
using BookingHotelRooms.Repositories;
using BookingHotelRooms.Repositories.IRepository;
using BookingHotelRooms.Services;
using BookingHotelRooms.Services.IServices;
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
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetBookings()
        {
            var model = await _bookingService.GetAllBookingsAsync(HttpContext);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> BookRoom(int roomId)
        {
            var model = await _bookingService.BookRoomAsync(roomId);

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> BookRoom(BookingDetailsViewModel booking)
        {

            var days = (booking.CheckOut - booking.CheckIn).Days;
            if (days <= 0)
            {
                ModelState.AddModelError("Days", "You should book at least one day to proceed!");
            }

            if (ModelState.IsValid)
            {             
                var model = await _bookingService.AddBookingAsync(booking, HttpContext);

                return RedirectToAction("BookingResult", "Booking", new { bookingId = model.BookingId });
            }

            return View(booking);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> BookingResult(string bookingId)
        {
            var model = await _bookingService.BookingResultAsync(bookingId);

            return View(model);

        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> FinishBooking(BookingResultViewModel bookingResult)
        {
            if (ModelState.IsValid)
            {
                await _bookingService.UpdateBookingStatusAsync(bookingResult);
                return RedirectToAction("Index", "Rooms");
            }

            return View(bookingResult);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CancelBooking(string bookingId)
        {
            await _bookingService.RemoveBookingAsync(bookingId);

            return RedirectToAction("Index", "Rooms");
        }
    }
}
