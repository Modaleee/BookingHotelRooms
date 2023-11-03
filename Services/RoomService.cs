using BookingHotelRooms.Models;
using BookingHotelRooms.Models.ViewModels;
using BookingHotelRooms.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingHotelRooms.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }


        public async Task<IEnumerable<Room>> GetAllRoomsAsync()
        {
            return await _roomRepository.GetAllEntities();
        }

        public async Task<Room> FindRoomAsync(int id)
        {
           var room = await _roomRepository.GetRoomById(id);

            return room;
        }

        public async Task AddRoomAsync(CreateRoomViewModel room)
        {
            var model = new Room
            {
                Description = room.Description,
                Price = room.Price,
                RoomNumber = room.RoomNumber
            };
            await _roomRepository.CreateEntity(model);
        }

        public async Task EditRoomAsync(EditRoomViewModel model)
        {
            var room = await _roomRepository.GetRoomById(model.RoomId);
            room.RoomId = model.RoomId;
            room.RoomNumber = model.RoomNumber;
            room.Description = model.Description;
            room.Price = model.Price;

            await _roomRepository.UpdateEntity(room);
        }

        public async Task RemoveRoomAsync(int id)
        {
            var room = await _roomRepository.GetRoomById(id);
            await _roomRepository.DeleteEntity(room);
        }

        public async Task<EditRoomViewModel> EditRoomAsync(int id)
        {
            var room = await FindRoomAsync(id);
            var model = new EditRoomViewModel
            {
                RoomId = room.RoomId,
                RoomNumber = room.RoomNumber,
                Description = room.Description,
                Price = room.Price
            };
            return model;
        }

        public async Task<bool> CheckForRoomNumberDuplicatesAsync(int number)
        {
            if (await _roomRepository.GetRoomByNumber(number) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

}
