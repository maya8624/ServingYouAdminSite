using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServingYouAdmin.Migrations
{
    public partial class SeedDataToRestaurant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Restaurant",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Description", "Email", "Name", "Phone", "Postcode", "State", "Street", "Town", "Unit" },
                values: new object[] { 1, new DateTime(2018, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "nice restaurant", "servingyou@domain.com", "Serving You", "02 1234 5678", "2000", 1, "Harbour Bridge", "Sydney", "Unit 100" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
