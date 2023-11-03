using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingHotelRooms.Models
{
    public class AppDbContext: IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Booking>()
                .Property(e => e.BookingStatus)
                .HasConversion<string>();

            //seeding room table
            modelBuilder.Entity<Room>().HasData(
                new Room { RoomId = 1, 
                    RoomNumber = 1,
                    Description = "Our Deln/Large Double also provides views over landscaped gardens. It has a seating area, digital safe and mini fridge. This room can be configured with either 2 single beds or zip and linked to provide a large double bed.",
                    Price = 17.99m, 
                    },
                new Room { RoomId = 2,
                    RoomNumber = 2, 
                    Description = "As our smallest budget rooms, the Compact bedrooms are suited for single occupancy or short-stay double occupancy as they have limited space and storage.",
                    Price = 22.99m,  },
                new Room { RoomId = 3, 
                    RoomNumber = 100, 
                    Description = "Our king size four poster provides views over landscaped gardens. It has a seating area, ample storage, digital safe and mini fridge.", 
                    Price = 29.99m, },
                new Room { RoomId = 4, 
                    RoomNumber = 22, 
                    Description = "Our king size sleigh bedded also provides views over landscaped gardens. It has ample storage, a seating area, digital safe and mini fridge.", 
                    Price = 100.99m, 
                     },
                new Room { RoomId = 5, 
                    RoomNumber = 5, 
                    Description = "Our Deluxe king size room has a seating area, ample storage, digital safe and mini fridge. This room can also be configured with an extra roll-away bed for families of 3.", 
                    Price = 80.99m,  }
                );

            //seeding appUser table
            string ADMIN_ID = "02174cf0–9412–4cfe-afbf-59f706d72cf6";
            string USER_ID = "341743f0-asd2–42de-afbf-59kmkkmk72cf6";

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN", Id = ADMIN_ID,  ConcurrencyStamp = ADMIN_ID},
                new IdentityRole { Name = "User", NormalizedName = "USER", Id = USER_ID,  ConcurrencyStamp = USER_ID }               
                );

            string Mada_ID = "22174cf0–9gg2–4cfe-afbf-59f706d72c99";
            string Andrei_ID = "960213f0-dsa8–42de-afbf-59kmkkmk72aaa";

            var appUserMada = new AppUser{ Id = Mada_ID, Email = "mada@yahoo.com", NormalizedEmail = "MADA@YAHOO.COM", 
                UserName = "mada", NormalizedUserName = "MADA"};

            var appUserAndrei = new AppUser{ Id = Andrei_ID, Email = "andrei@yahoo.com", NormalizedEmail = "ANDREI@YAHOO.COM", 
                UserName = "Andrei", NormalizedUserName = "ANDREI"};


            //set user password
            PasswordHasher<AppUser> ph = new PasswordHasher<AppUser>();
            appUserMada.PasswordHash = ph.HashPassword(appUserMada, "Mada@123");
            appUserAndrei.PasswordHash = ph.HashPassword(appUserMada, "Andrei@123");
            //seed user
            modelBuilder.Entity<AppUser>().HasData(appUserMada, appUserAndrei);

            //set user role to admin
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = ADMIN_ID, UserId = Mada_ID },
                new IdentityUserRole<string> { RoleId = USER_ID, UserId = Andrei_ID }
                );

            //seeding room table
            modelBuilder.Entity<Booking>().HasData(
                new Booking { BookingId= "9GADGDSHS1256",
                    RoomId = 1, AppUserId= "22174cf0–9gg2–4cfe-afbf-59f706d72c99", 
                    CheckIn = new DateTime(2023,10,27, 12,00,00),
                    CheckOut = new DateTime(2023,10,28, 12,00,00), 
                    TotalPrice = 17.99m, OrderDate=DateTime.Now, 
                    BookingStatus = Status.Completed},
                new Booking
                {
                    BookingId = "GTG5WR8T23",
                    RoomId = 2,
                    AppUserId = "22174cf0–9gg2–4cfe-afbf-59f706d72c99",
                    CheckIn = new DateTime(2023, 10, 29, 12, 00, 00),
                    CheckOut = new DateTime(2023, 10, 31, 12, 00, 00),
                    TotalPrice = 45.98m,
                    OrderDate = DateTime.Now,
                    BookingStatus = Status.Completed
                },
                new Booking
                {
                    BookingId = "GADGDHGS1251",
                    RoomId = 5,
                    AppUserId = "960213f0-dsa8–42de-afbf-59kmkkmk72aaa",
                    CheckIn = new DateTime(2023, 10, 27, 12, 00, 00),
                    CheckOut = new DateTime(2023, 10, 28, 12, 00, 00),
                    TotalPrice = 80.99m,
                    OrderDate = DateTime.Now,
                    BookingStatus = Status.Completed
                },
                new Booking
                {
                    BookingId = "GHDHREU4746",
                    RoomId = 1,
                    AppUserId = "960213f0-dsa8–42de-afbf-59kmkkmk72aaa",
                    CheckIn = new DateTime(2023, 10, 29, 12, 00, 00),
                    CheckOut = new DateTime(2023, 10, 30, 12, 00, 00),
                    TotalPrice = 17.99m,
                    OrderDate = DateTime.Now,
                    BookingStatus = Status.Completed
                },
                new Booking
                {
                    BookingId = "43635MGGJIRAO",
                    RoomId = 5,
                    AppUserId = "960213f0-dsa8–42de-afbf-59kmkkmk72aaa",
                    CheckIn = new DateTime(2023, 10, 25, 12, 00, 00),
                    CheckOut = new DateTime(2023, 10, 26, 12, 00, 00),
                    TotalPrice = 80.99m,
                    OrderDate = DateTime.Now,
                    BookingStatus = Status.Completed
                });
        }
    }
}
