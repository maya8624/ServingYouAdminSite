using Microsoft.EntityFrameworkCore.Migrations;

namespace ServingYouAdmin.Migrations
{
    public partial class AddRelationShipBtwEmployeeAndState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Employee_StateCode",
                table: "Employee",
                column: "StateCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_State_StateCode",
                table: "Employee",
                column: "StateCode",
                principalTable: "State",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_State_StateCode",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_StateCode",
                table: "Employee");
        }
    }
}
