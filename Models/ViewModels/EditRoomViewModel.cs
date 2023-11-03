using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookingHotelRooms.Models.ViewModels
{
    public class EditRoomViewModel
    {
        public int RoomId { get; set; }

        [Required, Range(1, Int32.MaxValue, ErrorMessage = "The room number can`t be a negative number!")]
        public int RoomNumber { get; set; }
        [Required, DataType(DataType.MultilineText), MinLength(5, ErrorMessage = "The description must be at least 5 characters long!")]
        public string Description { get; set; }

        [Required, DataType(DataType.Currency), Range(1, Int32.MaxValue, ErrorMessage = "The price can`t be a negative number!")]
        public decimal Price { get; set; }
    }
}
