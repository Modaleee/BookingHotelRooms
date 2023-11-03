using BookingHotelRooms.Models;
using EntityHotelRooms.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingHotelRooms.Repositories.IRepository
{
    public interface IBookingRepository : IGenericRepository<Booking>
    {
        Task<IEnumerable<Booking>> GetAllBookings();
        Task<Booking> GetBookingById(string id);
        Task<AppUser> GettUserByName(string user);
        Task<IEnumerable<Booking>> GetBookingByRoomId(int roomId);
    }
}
