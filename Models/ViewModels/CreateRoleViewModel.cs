using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookingHotelRooms.Models.Administration
{
    public class CreateRoleViewModel
    {
        [Required, MinLength(3, ErrorMessage ="User Role must be at least 3 characters long!"),DataType(DataType.Text)]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
}
