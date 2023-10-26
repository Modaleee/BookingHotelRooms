using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookingHotelRooms.Models.Administration
{
    public class EditRoleViewModel
    {
        [Required, MinLength(3, ErrorMessage = "The name must be at least 3 letters length"), DataType(DataType.Text)]
        public string RoleName { get; set; }
        public string Id { get; set; }
    }
}

