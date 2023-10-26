using BookingHotelRooms.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingHotelRooms.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly AppDbContext _context;

        public RoomRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddRoom(Room room)
        {
            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            var rooms = _context.Rooms;
            return await rooms.ToListAsync();
        }

        public async Task<Room> GetRoom(int id)
        {
            var room = await _context.Rooms.FirstOrDefaultAsync(x => x.RoomId == id);
            return room;
        }

        public async Task UpdateRoom(Room room)
        {
             _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
        }
        public async Task ChangeRoomAvailability(int roomId)
        {
            var room = await GetRoom(roomId);

            room.IsAvailable = false;

            await UpdateRoom(room);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> CheckForRoomNumberDuplicates(int number)
        {
            if (await _context.Rooms.FirstOrDefaultAsync(x=> x.RoomNumber == number) != null)
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
