using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingHotelRooms.Models
{
    public class AppUser : IdentityUser
    {
        public string City { get; set; }
        public string Adress { get; set; }
        public List<Booking> Bookings { get; set; }

    }
}
