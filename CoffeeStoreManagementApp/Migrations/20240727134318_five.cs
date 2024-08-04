using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeStoreManagementApp.Migrations
{
    public partial class five : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxAllowedToppings",
                table: "Coffees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Capacity",
                columns: table => new
                {
                    CapacityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CapacityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capacity", x => x.CapacityId);
                });

            migrationBuilder.CreateTable(
                name: "Milk",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Milk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NonDiaryAlternative",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonDiaryAlternative", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Topping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topping", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoffeeCapacity",
                columns: table => new
                {
                    CoffeeId = table.Column<int>(type: "int", nullable: false),
                    CapacityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeCapacity", x => new { x.CoffeeId, x.CapacityId });
                    table.ForeignKey(
                        name: "FK_CoffeeCapacity_Capacity_CapacityId",
                        column: x => x.CapacityId,
                        principalTable: "Capacity",
                        principalColumn: "CapacityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoffeeCapacity_Coffees_CoffeeId",
                        column: x => x.CoffeeId,
                        principalTable: "Coffees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoffeeMilk",
                columns: table => new
                {
                    CoffeeId = table.Column<int>(type: "int", nullable: false),
                    MilkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeMilk", x => new { x.CoffeeId, x.MilkId });
                    table.ForeignKey(
                        name: "FK_CoffeeMilk_Coffees_CoffeeId",
                        column: x => x.CoffeeId,
                        principalTable: "Coffees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoffeeMilk_Milk_MilkId",
                        column: x => x.MilkId,
                        principalTable: "Milk",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoffeeNonDairyAlternative",
                columns: table => new
                {
                    CoffeeId = table.Column<int>(type: "int", nullable: false),
                    NonDairyAlternativeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeNonDairyAlternative", x => new { x.CoffeeId, x.NonDairyAlternativeId });
                    table.ForeignKey(
                        name: "FK_CoffeeNonDairyAlternative_Coffees_CoffeeId",
                        column: x => x.CoffeeId,
                        principalTable: "Coffees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoffeeNonDairyAlternative_NonDiaryAlternative_NonDairyAlternativeId",
                        column: x => x.NonDairyAlternativeId,
                        principalTable: "NonDiaryAlternative",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoffeeTopping",
                columns: table => new
                {
                    CoffeeId = table.Column<int>(type: "int", nullable: false),
                    ToppingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeTopping", x => new { x.CoffeeId, x.ToppingId });
                    table.ForeignKey(
                        name: "FK_CoffeeTopping_Coffees_CoffeeId",
                        column: x => x.CoffeeId,
                        principalTable: "Coffees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoffeeTopping_Topping_ToppingId",
                        column: x => x.ToppingId,
                        principalTable: "Topping",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeCapacity_CapacityId",
                table: "CoffeeCapacity",
                column: "CapacityId");

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeMilk_MilkId",
                table: "CoffeeMilk",
                column: "MilkId");

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeNonDairyAlternative_NonDairyAlternativeId",
                table: "CoffeeNonDairyAlternative",
                column: "NonDairyAlternativeId");

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeTopping_ToppingId",
                table: "CoffeeTopping",
                column: "ToppingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoffeeCapacity");

            migrationBuilder.DropTable(
                name: "CoffeeMilk");

            migrationBuilder.DropTable(
                name: "CoffeeNonDairyAlternative");

            migrationBuilder.DropTable(
                name: "CoffeeTopping");

            migrationBuilder.DropTable(
                name: "Capacity");

            migrationBuilder.DropTable(
                name: "Milk");

            migrationBuilder.DropTable(
                name: "NonDiaryAlternative");

            migrationBuilder.DropTable(
                name: "Topping");

            migrationBuilder.DropColumn(
                name: "MaxAllowedToppings",
                table: "Coffees");
        }
    }
}
