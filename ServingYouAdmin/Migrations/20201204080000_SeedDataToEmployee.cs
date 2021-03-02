using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServingYouAdmin.Migrations
{
    public partial class SeedDataToEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Email", "FirstName", "IsDeleted", "JobType", "LastName", "Phone", "Position", "Postcode", "State", "Street", "Town", "Unit" },
                values: new object[] { 1, new DateTime(2020, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "andyj@domain.com", "Andy", false, 0, "Jung", "0422230861", 2, "2126", 1, "182 Boundary Rd", "Cherrybrook", "Unit 4" });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Email", "FirstName", "IsDeleted", "JobType", "LastName", "Phone", "Position", "Postcode", "State", "Street", "Town", "Unit" },
                values: new object[] { 2, new DateTime(2020, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "linaj@domain.com", "Lina", false, 0, "Jung", "0422230861", 1, "2126", 1, "182 Boundary Rd", "Cherrybrook", "Unit 4" });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Email", "FirstName", "IsDeleted", "JobType", "LastName", "Phone", "Position", "Postcode", "State", "Street", "Town", "Unit" },
                values: new object[] { 3, new DateTime(2020, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "samm@domain.com", "Sam", false, 1, "Monday", "0422230861", 0, "2154", 1, "22 Castle Towers", "Casle Hill", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
