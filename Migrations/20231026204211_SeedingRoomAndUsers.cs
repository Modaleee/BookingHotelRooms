using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingHotelRooms.Migrations
{
    public partial class SeedingRoomAndUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02174cf0–9412–4cfe-afbf-59f706d72cf6", "02174cf0–9412–4cfe-afbf-59f706d72cf6", "Admin", "ADMIN" },
                    { "341743f0-asd2–42de-afbf-59kmkkmk72cf6", "341743f0-asd2–42de-afbf-59kmkkmk72cf6", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Adress", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "22174cf0–9gg2–4cfe-afbf-59f706d72c99", 0, null, null, "8193a9f6-a190-4f4e-b8fc-23f46b6543e0", "mada@yahoo.com", false, false, null, "MADA@YAHOO.COM", "MADA", "AQAAAAEAACcQAAAAEEe/mYXlU7xEctvFNGr6124S+eeap/jbKEyOaSWprIdkA29akmGgC1HkaiI+ievKuw==", null, false, "ceda4c80-cac0-44ba-aaac-f7d011dbb9fa", false, "mada" },
                    { "960213f0-dsa8–42de-afbf-59kmkkmk72aaa", 0, null, null, "15e4ebe3-45e6-4cbf-a213-f10a42c48555", "andrei@yahoo.com", false, false, null, "ANDREI@YAHOO.COM", "ANDREI", "AQAAAAEAACcQAAAAEHo91imOQ12u36ICLNVdFBStx8Y11aYqtFPrfU1Et1WAp8ENKxuIGDcv2LV9CgWqgg==", null, false, "81be59be-5b08-430e-aaf0-12ef7873eadc", false, "Andrei" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "Description", "Price", "RoomNumber" },
                values: new object[] { 1, "First Room Description", 17.99m, 1 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "Description", "IsAvailable", "Price", "RoomNumber" },
                values: new object[] { 2, "Second Room Description", true, 22.99m, 2 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "Description", "Price", "RoomNumber" },
                values: new object[] { 3, "100th Room Description", 29.99m, 100 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "Description", "IsAvailable", "Price", "RoomNumber" },
                values: new object[,]
                {
                    { 4, "22th Room Description", true, 100.99m, 22 },
                    { 5, "Fifth Room Description", true, 80.99m, 5 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "02174cf0–9412–4cfe-afbf-59f706d72cf6", "22174cf0–9gg2–4cfe-afbf-59f706d72c99" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "341743f0-asd2–42de-afbf-59kmkkmk72cf6", "960213f0-dsa8–42de-afbf-59kmkkmk72aaa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "02174cf0–9412–4cfe-afbf-59f706d72cf6", "22174cf0–9gg2–4cfe-afbf-59f706d72c99" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "341743f0-asd2–42de-afbf-59kmkkmk72cf6", "960213f0-dsa8–42de-afbf-59kmkkmk72aaa" });

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22174cf0–9gg2–4cfe-afbf-59f706d72c99");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "960213f0-dsa8–42de-afbf-59kmkkmk72aaa");
        }
    }
}
