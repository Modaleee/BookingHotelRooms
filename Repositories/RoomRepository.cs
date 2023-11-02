using BookingHotelRooms.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingHotelRooms.Repositories
{
    public class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        private readonly AppDbContext _context;

        public RoomRepository(AppDbContext context) : base(context)
        {
            _context = context;
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
       
    }
}
