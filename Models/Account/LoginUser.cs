using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookingHotelRooms.Models.Account
{
    public class LoginUser
    {
        [Required]
        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Remember me?")]
        public bool RememberMe { get; set; }
    }
}
