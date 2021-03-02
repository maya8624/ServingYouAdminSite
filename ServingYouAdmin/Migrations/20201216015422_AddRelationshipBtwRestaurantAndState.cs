using Microsoft.EntityFrameworkCore.Migrations;

namespace ServingYouAdmin.Migrations
{
    public partial class AddRelationshipBtwRestaurantAndState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Restaurant");

            migrationBuilder.AddColumn<string>(
                name: "StateCode",
                table: "Restaurant",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 1,
                column: "StateCode",
                value: "NSW");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_State_StateCode",
                table: "Restaurant");

            migrationBuilder.DropIndex(
                name: "IX_Restaurant_StateCode",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "StateCode",
                table: "Restaurant");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Restaurant",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 1,
                column: "State",
                value: "NSW");
        }
    }
}
