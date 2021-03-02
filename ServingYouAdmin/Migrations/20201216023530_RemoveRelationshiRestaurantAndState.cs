using Microsoft.EntityFrameworkCore.Migrations;

namespace ServingYouAdmin.Migrations
{
    public partial class RemoveRelationshiRestaurantAndState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_State_StateCode",
                table: "Restaurant");

            migrationBuilder.DropIndex(
                name: "IX_Restaurant_StateCode",
                table: "Restaurant");

            migrationBuilder.AlterColumn<string>(
                name: "StateCode",
                table: "Restaurant",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StateCode",
                table: "Restaurant",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_StateCode",
                table: "Restaurant",
                column: "StateCode");

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
