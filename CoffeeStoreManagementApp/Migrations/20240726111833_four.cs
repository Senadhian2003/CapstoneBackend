using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeStoreManagementApp.Migrations
{
    public partial class four : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "UserCredentials",
                newName: "HashPassword");

            migrationBuilder.RenameColumn(
                name: "HashedPassword",
                table: "UserCredentials",
                newName: "HashKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HashPassword",
                table: "UserCredentials",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "HashKey",
                table: "UserCredentials",
                newName: "HashedPassword");
        }
    }
}
