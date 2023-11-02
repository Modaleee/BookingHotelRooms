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


        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            var rooms = _context.Rooms;
            return await rooms.ToListAsync();
        }

        public async Task<Room> GetRoomById(int id)
        {
            var room = await _context.Rooms.FirstOrDefaultAsync(x => x.RoomId == id);
            return room;
        }
        public async Task<Room> GetRoomByNumber(int number)
        {
            return await _context.Rooms.FirstOrDefaultAsync(x => x.RoomNumber == number);

        }

        public async Task CreateRoom(Room room)
        {
            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
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
    }
}
