﻿using BookingHotelRooms.Models;
using BookingHotelRooms.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingHotelRooms.Services.IServices
{
    public interface IBookingService
    {
        Task<Booking> FindBookingAsync(string id);
        Task<IEnumerable<IGrouping<string, Booking>>> GetAllBookingsAsync(HttpContext httpContext);
        Task<AppUser> GetContextUserAsync(HttpContext httpContext);
        Task AddBookingAsync(BookingDetailsViewModel booking, HttpContext context, string id);
        Task UpdateBookingAsync(BookingResultViewModel booking);
        Task RemoveBookingAsync(string id);
        Task<BookingResultViewModel> BookingResultAsync(string bookingId);
        Task<BookingDetailsViewModel> BookRoomAsync(int roomId);
        Task ChangeRoomAvailabilityAsync(int roomId);
    }
}
