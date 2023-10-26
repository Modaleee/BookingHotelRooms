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
        Task AddRoom(Room room);
        Task UpdateRoom(Room room);
        Task DeleteRoom(int id);
        Task<Room> GetRoom(int id);
        Task ChangeRoomAvailability(int roomId);
        Task<bool> CheckForRoomNumberDuplicates(int number);
    }
}
