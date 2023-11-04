using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookingHotelRooms.Models.ViewModels
{
    public class BookingDetailsViewModel
    {

        public List<DateInterval> RoomBookings { get; set; }
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        [Required]
        public DateTime CheckIn { get; set; }
        [Required]
        public DateTime CheckOut { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public class DateInterval
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
