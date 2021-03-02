using Microsoft.EntityFrameworkCore.Migrations;

namespace ServingYouAdmin.Migrations
{
    public partial class RemoveCasCadeBtwOrderAndOrderMenuAndEmployeeAndState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_State_StateCode",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderMenu_Order_OrderId",
                table: "OrderMenu");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_State_StateCode",
                table: "Employee",
                column: "StateCode",
                principalTable: "State",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderMenu_Order_OrderId",
                table: "OrderMenu",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_State_StateCode",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderMenu_Order_OrderId",
                table: "OrderMenu");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_State_StateCode",
                table: "Employee",
                column: "StateCode",
                principalTable: "State",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderMenu_Order_OrderId",
                table: "OrderMenu",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
