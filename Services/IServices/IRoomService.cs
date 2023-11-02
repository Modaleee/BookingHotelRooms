using BookingHotelRooms.Models;
using BookingHotelRooms.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingHotelRooms.Services
{
    public interface IRoomService
    {
        Task<IEnumerable<Room>> GetAllRoomsAsync();
        Task<Room> FindRoomAsync(int id);
        Task AddRoomAsync(CreateRoomViewModel room);
        Task<EditRoomViewModel> EditRoomAsync(int id);
        Task EditRoomAsync(EditRoomViewModel room);
        Task RemoveRoomAsync(int id);
        Task<bool> CheckForRoomNumberDuplicatesAsync(int number);       
    }
}
