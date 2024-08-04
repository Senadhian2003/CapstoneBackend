using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeStoreManagementApp.Migrations
{
    public partial class eleven : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsAvailable",
                table: "Coffees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Coffees",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsAvailable",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Coffees",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsAvailable",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Coffees",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsAvailable",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Coffees",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsAvailable",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Coffees",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsAvailable",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Coffees");
        }
    }
}
