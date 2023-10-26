using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingHotelRooms.Models.ViewModels
{
    public class UsersInRoleViewModel
    {
        public UsersInRoleViewModel()
        {
            Users = new List<AppUser>();
        }
        public string Id { get; set; }
        public string Role { get; set; }
        public List<AppUser> Users { get; set; }
    }
}
