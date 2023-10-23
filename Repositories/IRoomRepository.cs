using BookingHotelRooms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingHotelRooms.Repositories
{
    public class IRoomRepository
    {
        Room AddRoom(Room room);
    }
}
