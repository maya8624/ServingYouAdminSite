using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServingYouAdmin.Migrations
{
    public partial class ChangeTableNameCustomertoMembers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Order_CustomerId",
                table: "Order");

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

            migrationBuilder.DeleteData(
                table: "OrderMenu",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderMenu",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderMenu",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderMenu",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderMenu",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrderMenu",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateRegistered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_MemberId",
                table: "Order",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Members_MemberId",
                table: "Order",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Members_MemberId",
                table: "Order");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Order_MemberId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Order");

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateRegistered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Booking",
                columns: new[] { "Id", "DateBooked", "DateCreated", "DateUpdated", "EmployeeId", "FirstName", "LastName", "Method", "Mobile", "NumberinParty", "Status", "TableNo", "TimeBooked" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Andy", "Jung", 1, "0422230861", 5, 1, 1, "12:30" },
                    { 2, new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mary", "Winter", 2, "123456789", 2, 2, 2, "17:30" },
                    { 3, new DateTime(2020, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Joseph", "Summer", 1, "00000000000", 10, 1, 3, "18:30" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "DateRegistered", "DateUpdated", "Email", "FirstName", "IsDeleted", "LastName", "Password", "Phone" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "andyj@domain.com", "Andy", false, "Jung", "12345", "0422230861" },
                    { 2, new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "samq@domain.com", "Sam", false, "Queen", "12345", "0000000000" },
                    { 3, new DateTime(2020, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "josephk@domain.com", "Joseph", false, "King", "12345", "0234567891" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Email", "FirstName", "IsDeleted", "JobType", "LastName", "Phone", "Position", "Postcode", "StateCode", "Street", "Town", "Unit" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "andyj@domain.com", "Andy", false, 0, "Jung", "0422230861", 2, "2126", "NSW", "182 Boundary Rd", "Cherrybrook", "Unit 4" },
                    { 2, new DateTime(2020, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "linaj@domain.com", "Lina", false, 0, "Jung", "0422230861", 1, "2126", "NSW", "182 Boundary Rd", "Cherrybrook", "Unit 4" },
                    { 3, new DateTime(2020, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "samm@domain.com", "Sam", false, 1, "Monday", "0422230861", 0, "2154", "NSW", "22 Castle Towers", "Casle Hill", "" }
                });

            migrationBuilder.InsertData(
                table: "Restaurant",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Description", "Email", "Name", "Phone", "Postcode", "StateCode", "Street", "Town", "Unit" },
                values: new object[] { 1, new DateTime(2018, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "nice restaurant", "servingyou@domain.com", "Serving You", "02 1234 5678", "2000", "NSW", "Harbour Bridge", "Sydney", "Unit 100" });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "CustomerId", "EmployeeId", "OrderDate", "OrderMethod", "OrderStatus", "OrderTotal" },
                values: new object[] { 1, 1, 1, new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, 56.00m });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "CustomerId", "EmployeeId", "OrderDate", "OrderMethod", "OrderStatus", "OrderTotal" },
                values: new object[] { 3, 2, 1, new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, 50.00m });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "CustomerId", "EmployeeId", "OrderDate", "OrderMethod", "OrderStatus", "OrderTotal" },
                values: new object[] { 2, 3, 1, new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 2, 41.00m });

            migrationBuilder.InsertData(
                table: "OrderMenu",
                columns: new[] { "Id", "DateCreated", "MenuId", "OrderId", "Price", "Quantity" },
                values: new object[,]
                {
                    { 5, new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 18.00m, 2 },
                    { 6, new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 20.00m, 1 },
                    { 3, new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 3, 25.00m, 1 },
                    { 4, new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 25.00m, 1 },
                    { 1, new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 20.00m, 1 },
                    { 2, new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 2, 21.00m, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
