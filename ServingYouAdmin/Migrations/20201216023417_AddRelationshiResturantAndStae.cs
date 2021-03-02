using Microsoft.EntityFrameworkCore.Migrations;

namespace ServingYouAdmin.Migrations
{
    public partial class AddRelationshiResturantAndStae : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        }
    }
}
