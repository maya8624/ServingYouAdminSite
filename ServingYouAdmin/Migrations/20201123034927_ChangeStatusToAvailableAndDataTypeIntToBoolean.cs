using Microsoft.EntityFrameworkCore.Migrations;

namespace ServingYouAdmin.Migrations
{
    public partial class ChangeStatusToAvailableAndDataTypeIntToBoolean : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Menu");

            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "Menu",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Available",
                table: "Menu");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Menu",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
