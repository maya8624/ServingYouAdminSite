using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServingYouAdmin.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Booking",
                columns: new[] { "Id", "BookingDate", "BookingTime", "DateCreated", "DateUpdated", "EmployeeId", "FirstName", "LastName", "Method", "Mobile", "NumberinParty", "Status", "TableId" },
                values: new object[] { 1, new DateTime(2020, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "12:30", new DateTime(2020, 11, 30, 12, 30, 3, 655, DateTimeKind.Local).AddTicks(6534), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Andy", "Jung", 1, "0422230861", 5, 1, 1 });

            migrationBuilder.InsertData(
                table: "Booking",
                columns: new[] { "Id", "BookingDate", "BookingTime", "DateCreated", "DateUpdated", "EmployeeId", "FirstName", "LastName", "Method", "Mobile", "NumberinParty", "Status", "TableId" },
                values: new object[] { 2, new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "17:30", new DateTime(2020, 11, 30, 12, 30, 3, 657, DateTimeKind.Local).AddTicks(9591), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mary", "Winter", 2, "123456789", 2, 2, 2 });

            migrationBuilder.InsertData(
                table: "Booking",
                columns: new[] { "Id", "BookingDate", "BookingTime", "DateCreated", "DateUpdated", "EmployeeId", "FirstName", "LastName", "Method", "Mobile", "NumberinParty", "Status", "TableId" },
                values: new object[] { 3, new DateTime(2020, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "18:30", new DateTime(2020, 11, 30, 12, 30, 3, 657, DateTimeKind.Local).AddTicks(9766), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Joseph", "Summer", 1, "00000000000", 10, 1, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
