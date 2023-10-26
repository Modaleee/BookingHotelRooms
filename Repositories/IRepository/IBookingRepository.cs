using BookingHotelRooms.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingHotelRooms.Repositories.IRepository
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetAllBookings();
        Task<Booking> GetBooking(string id);
        Task CreateBooking(Booking booking);
        Task<AppUser> GetContextUser(HttpContext httpContext);
        Task UpdateBookingUser(Booking booking);
        Task DeleteBooking(string id);
    }
}
