using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingHotelRooms.Migrations
{
    public partial class BookingIdType2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookingId2",
                table: "Bookings",
                newName: "BookingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "Bookings",
                newName: "BookingId2");
        }
    }
}
