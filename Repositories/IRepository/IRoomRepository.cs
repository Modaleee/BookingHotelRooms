using BookingHotelRooms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingHotelRooms.Repositories
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAllRooms();
        Task<Room> GetRoomById(int id);
        Task<Room> GetRoomByNumber(int number);
        Task CreateRoom(Room room);
        Task UpdateRoom(Room room);
        Task DeleteRoom(int id);
    }
}
