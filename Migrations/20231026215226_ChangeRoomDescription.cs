using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingHotelRooms.Migrations
{
    public partial class ChangeRoomDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22174cf0–9gg2–4cfe-afbf-59f706d72c99",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c067489e-7fb7-4bd2-831d-69740b1991e9", "AQAAAAEAACcQAAAAEBs4Lp44aHmH8Xo1QkRpnXC7MoksSLWn1WQ3GA/B6+2D0BJwxTTA5Aa7JUNtgYkgOw==", "9d7dbf66-d18e-4a36-bef4-20a0bb241eeb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "960213f0-dsa8–42de-afbf-59kmkkmk72aaa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40e51b4b-c55e-4713-8e2e-0615eb5cf8f1", "AQAAAAEAACcQAAAAEKQDsfNMMcq5k1XRcY7kZsn/xq0xexI3jGt1zn4Q4/kHmrzD5DNQPg4BY14EBRYhEw==", "fa1c6665-4b1e-4ef5-bb86-355e4743fa52" });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: "43635MGGJIRAO",
                column: "OrderDate",
                value: new DateTime(2023, 10, 27, 0, 52, 25, 403, DateTimeKind.Local).AddTicks(4781));

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: "9GADGDSHS1256",
                column: "OrderDate",
                value: new DateTime(2023, 10, 27, 0, 52, 25, 399, DateTimeKind.Local).AddTicks(8290));

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: "GADGDHGS1251",
                column: "OrderDate",
                value: new DateTime(2023, 10, 27, 0, 52, 25, 403, DateTimeKind.Local).AddTicks(4772));

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: "GHDHREU4746",
                column: "OrderDate",
                value: new DateTime(2023, 10, 27, 0, 52, 25, 403, DateTimeKind.Local).AddTicks(4778));

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: "GTG5WR8T23",
                column: "OrderDate",
                value: new DateTime(2023, 10, 27, 0, 52, 25, 403, DateTimeKind.Local).AddTicks(4742));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 1,
                column: "Description",
                value: "Our Deln/Large Double also provides views over landscaped gardens. It has a seating area, digital safe and mini fridge. This room can be configured with either 2 single beds or zip and linked to provide a large double bed.");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 2,
                column: "Description",
                value: "As our smallest budget rooms, the Compact bedrooms are suited for single occupancy or short-stay double occupancy as they have limited space and storage.");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 3,
                column: "Description",
                value: "Our king size four poster provides views over landscaped gardens. It has a seating area, ample storage, digital safe and mini fridge.");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 4,
                column: "Description",
                value: "Our king size sleigh bedded also provides views over landscaped gardens. It has ample storage, a seating area, digital safe and mini fridge.");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 5,
                column: "Description",
                value: "Our Deluxe king size room has a seating area, ample storage, digital safe and mini fridge. This room can also be configured with an extra roll-away bed for families of 3.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: "43635MGGJIRAO",
                column: "OrderDate",
                value: new DateTime(2023, 10, 27, 0, 12, 33, 42, DateTimeKind.Local).AddTicks(5309));

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: "9GADGDSHS1256",
                column: "OrderDate",
                value: new DateTime(2023, 10, 27, 0, 12, 33, 38, DateTimeKind.Local).AddTicks(5183));

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: "GADGDHGS1251",
                column: "OrderDate",
                value: new DateTime(2023, 10, 27, 0, 12, 33, 42, DateTimeKind.Local).AddTicks(5300));

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: "GHDHREU4746",
                column: "OrderDate",
                value: new DateTime(2023, 10, 27, 0, 12, 33, 42, DateTimeKind.Local).AddTicks(5305));

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: "GTG5WR8T23",
                column: "OrderDate",
                value: new DateTime(2023, 10, 27, 0, 12, 33, 42, DateTimeKind.Local).AddTicks(5266));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 1,
                column: "Description",
                value: "First Room Description");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 2,
                column: "Description",
                value: "Second Room Description");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 3,
                column: "Description",
                value: "100th Room Description");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 4,
                column: "Description",
                value: "22th Room Description");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 5,
                column: "Description",
                value: "Fifth Room Description");
        }
    }
}
