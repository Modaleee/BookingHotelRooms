using BookingHotelRooms.Models;
using EntityHotelRooms.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingHotelRooms.Repositories
{
    public interface IRoomRepository : IGenericRepository<Room>
    {
        Task<Room> GetRoomById(int id);
        Task<Room> GetRoomByNumber(int number);
    }
}
