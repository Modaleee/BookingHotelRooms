using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookingHotelRooms.Models
{
    public class Booking
    {
        [Key]
        public string BookingId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public DateTime OrderDate { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        public string AppUserId { get; set; }
        public virtual AppUser ApplicationUser { get; set; }
        public decimal TotalPrice { get; set; }
        public Status BookingStatus { get; set; }
    }
    
    public enum Status
    {
        Draft,
        Completed
    }
}
