using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingHotelRooms.Models.ViewModels
{
    public class BookingResultViewModel
    {
        public string BookingId { get; set; }
        public int RoomNumber { get; set; }

        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
