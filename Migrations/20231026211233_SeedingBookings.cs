using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingHotelRooms.Migrations
{
    public partial class SeedingBookings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22174cf0–9gg2–4cfe-afbf-59f706d72c99",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df62e5e9-1a75-4f3c-87c0-6ab4fb5e449d", "AQAAAAEAACcQAAAAEJj2oEEflG3W/wMvcwufShiiEBcX+8l0DeEZ6yJ3y6EL4Alk5zMTb4FlTozl8QA9fg==", "525a5b38-94f3-41a8-b34e-28a3a3fe4f27" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "960213f0-dsa8–42de-afbf-59kmkkmk72aaa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2898abc8-ef3b-4ec3-95bc-dcada25703cb", "AQAAAAEAACcQAAAAEJcRbStj0EBk5Kp97KHwsbqpiBlVgFYaojKBI/CoxVzGlfgulywu2vatx1rVI9qHHg==", "30e6b3cf-6b48-41bf-b587-271ba18cf2e3" });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "AppUserId", "BookingStatus", "CheckIn", "CheckOut", "OrderDate", "RoomId", "TotalPrice" },
                values: new object[,]
                {
                    { "9GADGDSHS1256", "22174cf0–9gg2–4cfe-afbf-59f706d72c99", "Completed", new DateTime(2023, 10, 27, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 27, 0, 12, 33, 38, DateTimeKind.Local).AddTicks(5183), 1, 17.99m },
                    { "GTG5WR8T23", "22174cf0–9gg2–4cfe-afbf-59f706d72c99", "Completed", new DateTime(2023, 10, 29, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 31, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 27, 0, 12, 33, 42, DateTimeKind.Local).AddTicks(5266), 2, 45.98m },
                    { "GADGDHGS1251", "960213f0-dsa8–42de-afbf-59kmkkmk72aaa", "Completed", new DateTime(2023, 10, 27, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 27, 0, 12, 33, 42, DateTimeKind.Local).AddTicks(5300), 5, 80.99m },
                    { "GHDHREU4746", "960213f0-dsa8–42de-afbf-59kmkkmk72aaa", "Completed", new DateTime(2023, 10, 29, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 27, 0, 12, 33, 42, DateTimeKind.Local).AddTicks(5305), 1, 17.99m },
                    { "43635MGGJIRAO", "960213f0-dsa8–42de-afbf-59kmkkmk72aaa", "Completed", new DateTime(2023, 10, 25, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 26, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 27, 0, 12, 33, 42, DateTimeKind.Local).AddTicks(5309), 5, 80.99m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: "43635MGGJIRAO");

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: "9GADGDSHS1256");

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: "GADGDHGS1251");

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: "GHDHREU4746");

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: "GTG5WR8T23");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22174cf0–9gg2–4cfe-afbf-59f706d72c99",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8193a9f6-a190-4f4e-b8fc-23f46b6543e0", "AQAAAAEAACcQAAAAEEe/mYXlU7xEctvFNGr6124S+eeap/jbKEyOaSWprIdkA29akmGgC1HkaiI+ievKuw==", "ceda4c80-cac0-44ba-aaac-f7d011dbb9fa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "960213f0-dsa8–42de-afbf-59kmkkmk72aaa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "15e4ebe3-45e6-4cbf-a213-f10a42c48555", "AQAAAAEAACcQAAAAEHo91imOQ12u36ICLNVdFBStx8Y11aYqtFPrfU1Et1WAp8ENKxuIGDcv2LV9CgWqgg==", "81be59be-5b08-430e-aaf0-12ef7873eadc" });
        }
    }
}
