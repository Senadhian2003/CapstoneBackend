using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeStoreManagementApp.Migrations
{
    public partial class seven : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PricePerCoffee",
                table: "CartItems",
                newName: "PricePerCartItem");

            migrationBuilder.AddColumn<double>(
                name: "CartItemPrice",
                table: "CartItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Discount",
                table: "CartItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartItemPrice",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "PricePerCartItem",
                table: "CartItems",
                newName: "PricePerCoffee");
        }
    }
}
