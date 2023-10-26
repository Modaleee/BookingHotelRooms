using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookingHotelRooms.Models.Account
{
    public class RegisterUser
    {
        [Required, MinLength(3)]
        public string Name { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, DataType(DataType.Password), MinLength(6, ErrorMessage = "The password must be of length at least 6!")]
        public string Password { get; set; }

        [Required, DataType(DataType.Password), Compare("Password", ErrorMessage = "Passwords are not matching!")]
        public string ConfirmPassword { get; set; }
    }
}
