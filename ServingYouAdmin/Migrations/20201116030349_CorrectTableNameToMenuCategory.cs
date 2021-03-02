using Microsoft.EntityFrameworkCore.Migrations;

namespace ServingYouAdmin.Migrations
{
    public partial class CorrectTableNameToMenuCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuCagegory",
                table: "MenuCagegory");

            migrationBuilder.RenameTable(
                name: "MenuCagegory",
                newName: "MenuCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuCategory",
                table: "MenuCategory",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuCategory",
                table: "MenuCategory");

            migrationBuilder.RenameTable(
                name: "MenuCategory",
                newName: "MenuCagegory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuCagegory",
                table: "MenuCagegory",
                column: "Id");
        }
    }
}
