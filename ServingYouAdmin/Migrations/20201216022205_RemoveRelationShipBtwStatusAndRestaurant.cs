using Microsoft.EntityFrameworkCore.Migrations;

namespace ServingYouAdmin.Migrations
{
    public partial class RemoveRelationShipBtwStatusAndRestaurant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
              name: "FK_Restaurant_State_StateCode",
              table: "Restaurant");

            migrationBuilder.DropIndex(
                name: "IX_Restaurant_StateCode",
                table: "Restaurant");
     
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
