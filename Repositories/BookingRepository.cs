using BookingHotelRooms.Models;
using BookingHotelRooms.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingHotelRooms.Repositories
{
    public class BookingRepository : IBookingRepository
    {

        private readonly AppDbContext _context;

        public BookingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateBooking(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }

        public async Task<Booking> GetBooking(string id)
        {
            var booking = await _context.Bookings.Include(x => x.Room)
                .FirstOrDefaultAsync(x => x.BookingId == id);

            return booking;
        }

        public async Task<AppUser> GetContextUser(HttpContext httpContext)
        {
            //add null case
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == httpContext.User.Identity.Name);

            return user;
        }

        public async Task UpdateBookingUser(Booking booking)
        {
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBooking(string id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Booking>> GetAllBookings()
        {
            var bookings = _context.Bookings.Include(x=>x.Room).Include(x=>x.ApplicationUser);
            return await bookings.ToListAsync();
        }
    }
}
