using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServingYouAdmin.Migrations
{
    public partial class SeedDataToOrderAndOrderMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "CustomerId", "DateCreated", "DateUpdated", "EmployeeId", "OrderDate", "OrderMethod", "OrderStatus", "OrderTotal" },
                values: new object[] { 1, 1, new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, 56.00m });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "CustomerId", "DateCreated", "DateUpdated", "EmployeeId", "OrderDate", "OrderMethod", "OrderStatus", "OrderTotal" },
                values: new object[] { 2, 3, new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, 41.00m });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "CustomerId", "DateCreated", "DateUpdated", "EmployeeId", "OrderDate", "OrderMethod", "OrderStatus", "OrderTotal" },
                values: new object[] { 3, 2, new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 50.00m });

            migrationBuilder.InsertData(
                table: "OrderMenu",
                columns: new[] { "Id", "DateCreated", "MenuId", "OrderId", "Price", "Quantity" },
                values: new object[,]
                {
                    { 5, new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 18.00m, 2 },
                    { 6, new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 20.00m, 1 },
                    { 1, new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 20.00m, 1 },
                    { 2, new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 2, 21.00m, 1 },
                    { 3, new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 3, 25.00m, 1 },
                    { 4, new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 25.00m, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
