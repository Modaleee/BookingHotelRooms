using BookingHotelRooms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingHotelRooms.Repositories.IRepository
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetAllBookings();
        Task<Booking> GetBookingById(string id);
        Task CreateBooking(Booking booking);
        Task<AppUser> GettUserByName(string user);
        Task UpdateBooking(Booking booking);
        Task DeleteBooking(string id);
    }
}
