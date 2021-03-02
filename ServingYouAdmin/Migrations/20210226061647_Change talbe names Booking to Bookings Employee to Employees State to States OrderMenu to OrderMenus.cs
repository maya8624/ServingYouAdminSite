using Microsoft.EntityFrameworkCore.Migrations;

namespace ServingYouAdmin.Migrations
{
    public partial class ChangetalbenamesBookingtoBookingsEmployeetoEmployeesStatetoStatesOrderMenutoOrderMenus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_State_StateCode",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderMenu_Menu_MenuId",
                table: "OrderMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderMenu_Orders_OrderId",
                table: "OrderMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_State_StateCode",
                table: "Restaurant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_State",
                table: "State");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Restaurant",
                table: "Restaurant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderMenu",
                table: "OrderMenu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menu",
                table: "Menu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Booking",
                table: "Booking");

            migrationBuilder.RenameTable(
                name: "State",
                newName: "States");

            migrationBuilder.RenameTable(
                name: "Restaurant",
                newName: "Restaurants");

            migrationBuilder.RenameTable(
                name: "OrderMenu",
                newName: "OrderMenus");

            migrationBuilder.RenameTable(
                name: "Menu",
                newName: "Menus");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "Booking",
                newName: "Bookings");

            migrationBuilder.RenameIndex(
                name: "IX_Restaurant_StateCode",
                table: "Restaurants",
                newName: "IX_Restaurants_StateCode");

            migrationBuilder.RenameIndex(
                name: "IX_OrderMenu_OrderId",
                table: "OrderMenus",
                newName: "IX_OrderMenus_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderMenu_MenuId",
                table: "OrderMenus",
                newName: "IX_OrderMenus_MenuId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_StateCode",
                table: "Employees",
                newName: "IX_Employees_StateCode");

            migrationBuilder.AlterColumn<decimal>(
                name: "SpecialPrice",
                table: "Menus",
                type: "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_States",
                table: "States",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Restaurants",
                table: "Restaurants",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderMenus",
                table: "OrderMenus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menus",
                table: "Menus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_States_StateCode",
                table: "Employees",
                column: "StateCode",
                principalTable: "States",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderMenus_Menus_MenuId",
                table: "OrderMenus",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderMenus_Orders_OrderId",
                table: "OrderMenus",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_States_StateCode",
                table: "Restaurants",
                column: "StateCode",
                principalTable: "States",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_States_StateCode",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderMenus_Menus_MenuId",
                table: "OrderMenus");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderMenus_Orders_OrderId",
                table: "OrderMenus");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_States_StateCode",
                table: "Restaurants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_States",
                table: "States");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Restaurants",
                table: "Restaurants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderMenus",
                table: "OrderMenus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menus",
                table: "Menus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.RenameTable(
                name: "States",
                newName: "State");

            migrationBuilder.RenameTable(
                name: "Restaurants",
                newName: "Restaurant");

            migrationBuilder.RenameTable(
                name: "OrderMenus",
                newName: "OrderMenu");

            migrationBuilder.RenameTable(
                name: "Menus",
                newName: "Menu");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.RenameTable(
                name: "Bookings",
                newName: "Booking");

            migrationBuilder.RenameIndex(
                name: "IX_Restaurants_StateCode",
                table: "Restaurant",
                newName: "IX_Restaurant_StateCode");

            migrationBuilder.RenameIndex(
                name: "IX_OrderMenus_OrderId",
                table: "OrderMenu",
                newName: "IX_OrderMenu_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderMenus_MenuId",
                table: "OrderMenu",
                newName: "IX_OrderMenu_MenuId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_StateCode",
                table: "Employee",
                newName: "IX_Employee_StateCode");

            migrationBuilder.AlterColumn<decimal>(
                name: "SpecialPrice",
                table: "Menu",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_State",
                table: "State",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Restaurant",
                table: "Restaurant",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderMenu",
                table: "OrderMenu",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menu",
                table: "Menu",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booking",
                table: "Booking",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_State_StateCode",
                table: "Employee",
                column: "StateCode",
                principalTable: "State",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderMenu_Menu_MenuId",
                table: "OrderMenu",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderMenu_Orders_OrderId",
                table: "OrderMenu",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_State_StateCode",
                table: "Restaurant",
                column: "StateCode",
                principalTable: "State",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
