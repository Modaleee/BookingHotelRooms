using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingHotelRooms.Migrations
{
    public partial class CreatingAndSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22174cf0–9gg2–4cfe-afbf-59f706d72c99",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a9923d3-4ab4-4e47-8752-3e228c2ce9a1", "AQAAAAEAACcQAAAAEIlQyL1UrGU2pPbvE1wjqUYqEaINSFIgredhf8lJnx67oxxxT4/9FYk4+XXqnUWXUw==", "2ff1f8c1-76ec-4cc0-9906-d86133bdb3bc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "960213f0-dsa8–42de-afbf-59kmkkmk72aaa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1946071c-705d-4b6e-8b84-05516363825b", "AQAAAAEAACcQAAAAEO6Kt2M6Rnac/XQIqIEU5i9/EN6ZgaHrIdHLdnJWHh3yEBCS1s8gARBj2EOMwZ1c/A==", "70e7b97f-28f2-48a6-bf21-f1c124f97d43" });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: "43635MGGJIRAO",
                column: "OrderDate",
                value: new DateTime(2023, 10, 27, 14, 6, 7, 547, DateTimeKind.Local).AddTicks(1267));

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: "9GADGDSHS1256",
                column: "OrderDate",
                value: new DateTime(2023, 10, 27, 14, 6, 7, 542, DateTimeKind.Local).AddTicks(2467));

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: "GADGDHGS1251",
                column: "OrderDate",
                value: new DateTime(2023, 10, 27, 14, 6, 7, 547, DateTimeKind.Local).AddTicks(1255));

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: "GHDHREU4746",
                column: "OrderDate",
                value: new DateTime(2023, 10, 27, 14, 6, 7, 547, DateTimeKind.Local).AddTicks(1262));

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: "GTG5WR8T23",
                column: "OrderDate",
                value: new DateTime(2023, 10, 27, 14, 6, 7, 547, DateTimeKind.Local).AddTicks(1211));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
