using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookingHotelRooms.Models.Administration
{
    public class EditUserViewModel
    {
        public string UserName { get; set; }

        [Display(Name = "User Role")]
        public int SelectedUserRoleId { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}
