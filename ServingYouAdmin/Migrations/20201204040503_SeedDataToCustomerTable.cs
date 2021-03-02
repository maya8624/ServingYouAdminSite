using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServingYouAdmin.Migrations
{
    public partial class SeedDataToCustomerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "DateRegistered", "DateUpdated", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { 1, new DateTime(2020, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "andyj@domain.com", "Andy", "Jung", "12345", "0422230861" });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "DateRegistered", "DateUpdated", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { 2, new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "samq@domain.com", "Sam", "Queen", "12345", "0000000000" });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "DateRegistered", "DateUpdated", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { 3, new DateTime(2020, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "josephk@domain.com", "Joseph", "King", "12345", "0234567891" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
