using Microsoft.EntityFrameworkCore.Migrations;

namespace ServingYouAdmin.Migrations
{
    public partial class DropColumnsFromOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberinParty",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "TableNo",
                table: "Order");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberinParty",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TableNo",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
