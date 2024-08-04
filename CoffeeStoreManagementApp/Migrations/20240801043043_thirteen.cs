using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeStoreManagementApp.Migrations
{
    public partial class thirteen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeCredentials_Users_UserId",
                table: "EmployeeCredentials");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeCredentials_UserId",
                table: "EmployeeCredentials");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "EmployeeCredentials");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCredentials_EmployeeId",
                table: "EmployeeCredentials",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeCredentials_Employees_EmployeeId",
                table: "EmployeeCredentials",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeCredentials_Employees_EmployeeId",
                table: "EmployeeCredentials");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeCredentials_EmployeeId",
                table: "EmployeeCredentials");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "EmployeeCredentials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCredentials_UserId",
                table: "EmployeeCredentials",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeCredentials_Users_UserId",
                table: "EmployeeCredentials",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
