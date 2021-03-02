using Microsoft.EntityFrameworkCore.Migrations;

namespace ServingYouAdmin.Migrations
{
    public partial class ChangeTableNameOfOrderDetailToOrderMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Menu_MenuId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Order_OrderId",
                table: "OrderDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetail",
                table: "OrderDetail");

            migrationBuilder.RenameTable(
                name: "OrderDetail",
                newName: "OrderMenu");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderMenu",
                newName: "IX_OrderMenu_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_MenuId",
                table: "OrderMenu",
                newName: "IX_OrderMenu_MenuId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderMenu",
                table: "OrderMenu",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderMenu_Menu_MenuId",
                table: "OrderMenu",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderMenu_Order_OrderId",
                table: "OrderMenu",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderMenu_Menu_MenuId",
                table: "OrderMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderMenu_Order_OrderId",
                table: "OrderMenu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderMenu",
                table: "OrderMenu");

            migrationBuilder.RenameTable(
                name: "OrderMenu",
                newName: "OrderDetail");

            migrationBuilder.RenameIndex(
                name: "IX_OrderMenu_OrderId",
                table: "OrderDetail",
                newName: "IX_OrderDetail_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderMenu_MenuId",
                table: "OrderDetail",
                newName: "IX_OrderDetail_MenuId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetail",
                table: "OrderDetail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Menu_MenuId",
                table: "OrderDetail",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Order_OrderId",
                table: "OrderDetail",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
