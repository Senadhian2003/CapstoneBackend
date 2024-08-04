using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeStoreManagementApp.Migrations
{
    public partial class six : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeCapacity_Capacity_CapacityId",
                table: "CoffeeCapacity");

            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeCapacity_Coffees_CoffeeId",
                table: "CoffeeCapacity");

            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeMilk_Coffees_CoffeeId",
                table: "CoffeeMilk");

            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeMilk_Milk_MilkId",
                table: "CoffeeMilk");

            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeNonDairyAlternative_Coffees_CoffeeId",
                table: "CoffeeNonDairyAlternative");

            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeNonDairyAlternative_NonDiaryAlternative_NonDairyAlternativeId",
                table: "CoffeeNonDairyAlternative");

            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeTopping_Coffees_CoffeeId",
                table: "CoffeeTopping");

            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeTopping_Topping_ToppingId",
                table: "CoffeeTopping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Topping",
                table: "Topping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NonDiaryAlternative",
                table: "NonDiaryAlternative");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Milk",
                table: "Milk");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoffeeTopping",
                table: "CoffeeTopping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoffeeNonDairyAlternative",
                table: "CoffeeNonDairyAlternative");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoffeeMilk",
                table: "CoffeeMilk");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoffeeCapacity",
                table: "CoffeeCapacity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Capacity",
                table: "Capacity");

            migrationBuilder.DeleteData(
                table: "CoffeeSauces",
                keyColumns: new[] { "CoffeeId", "SauceId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.RenameTable(
                name: "Topping",
                newName: "Toppings");

            migrationBuilder.RenameTable(
                name: "NonDiaryAlternative",
                newName: "NonDiaryAlternatives");

            migrationBuilder.RenameTable(
                name: "Milk",
                newName: "Milks");

            migrationBuilder.RenameTable(
                name: "CoffeeTopping",
                newName: "CoffeeToppings");

            migrationBuilder.RenameTable(
                name: "CoffeeNonDairyAlternative",
                newName: "CoffeeNonDairyAlternatives");

            migrationBuilder.RenameTable(
                name: "CoffeeMilk",
                newName: "CoffeeMilks");

            migrationBuilder.RenameTable(
                name: "CoffeeCapacity",
                newName: "CoffeeCapacities");

            migrationBuilder.RenameTable(
                name: "Capacity",
                newName: "Capacities");

            migrationBuilder.RenameIndex(
                name: "IX_CoffeeTopping_ToppingId",
                table: "CoffeeToppings",
                newName: "IX_CoffeeToppings_ToppingId");

            migrationBuilder.RenameIndex(
                name: "IX_CoffeeNonDairyAlternative_NonDairyAlternativeId",
                table: "CoffeeNonDairyAlternatives",
                newName: "IX_CoffeeNonDairyAlternatives_NonDairyAlternativeId");

            migrationBuilder.RenameIndex(
                name: "IX_CoffeeMilk_MilkId",
                table: "CoffeeMilks",
                newName: "IX_CoffeeMilks_MilkId");

            migrationBuilder.RenameIndex(
                name: "IX_CoffeeCapacity_CapacityId",
                table: "CoffeeCapacities",
                newName: "IX_CoffeeCapacities_CapacityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Toppings",
                table: "Toppings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NonDiaryAlternatives",
                table: "NonDiaryAlternatives",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Milks",
                table: "Milks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoffeeToppings",
                table: "CoffeeToppings",
                columns: new[] { "CoffeeId", "ToppingId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoffeeNonDairyAlternatives",
                table: "CoffeeNonDairyAlternatives",
                columns: new[] { "CoffeeId", "NonDairyAlternativeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoffeeMilks",
                table: "CoffeeMilks",
                columns: new[] { "CoffeeId", "MilkId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoffeeCapacities",
                table: "CoffeeCapacities",
                columns: new[] { "CoffeeId", "CapacityId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Capacities",
                table: "Capacities",
                column: "CapacityId");

            migrationBuilder.InsertData(
                table: "Capacities",
                columns: new[] { "CapacityId", "CapacityName", "Price" },
                values: new object[,]
                {
                    { 1, "Short", 0.0 },
                    { 2, "Medium", 0.5 },
                    { 3, "Tall", 1.0 }
                });

            migrationBuilder.InsertData(
                table: "CoffeeSauces",
                columns: new[] { "CoffeeId", "SauceId" },
                values: new object[] { 3, 3 });

            migrationBuilder.UpdateData(
                table: "Coffees",
                keyColumn: "Id",
                keyValue: 1,
                column: "MaxAllowedToppings",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Coffees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "MaxAllowedToppings", "Name" },
                values: new object[] { "Espresso with steamed milk foam", 2, "Cappuccino" });

            migrationBuilder.UpdateData(
                table: "Coffees",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "MaxAllowedToppings", "Name" },
                values: new object[] { "Espresso with steamed milk", 2, "Latte" });

            migrationBuilder.UpdateData(
                table: "Coffees",
                keyColumn: "Id",
                keyValue: 4,
                column: "MaxAllowedToppings",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Coffees",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "MaxAllowedSauces", "MaxAllowedToppings" },
                values: new object[] { 2, 3 });

            migrationBuilder.InsertData(
                table: "Milks",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Skimmed Milk", 0.0 },
                    { 2, "Whole Milk", 0.0 },
                    { 3, "Semi-Skimmed Milk", 0.0 },
                    { 4, "Lactose-Free Milk", 0.5 }
                });

            migrationBuilder.InsertData(
                table: "NonDiaryAlternatives",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Soy Milk", 0.75 },
                    { 2, "Almond Milk", 0.75 },
                    { 3, "Oat Milk", 0.75 }
                });

            migrationBuilder.UpdateData(
                table: "Sauces",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 0.5);

            migrationBuilder.UpdateData(
                table: "Sauces",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 0.5);

            migrationBuilder.UpdateData(
                table: "Sauces",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Pumpkin Spice Syrup");

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Whipped Cream", 0.5 },
                    { 2, "Chocolate Chips", 0.5 },
                    { 3, "Cinnamon Powder", 0.25 },
                    { 4, "Caramel Drizzle", 0.5 },
                    { 5, "Cocoa Powder", 0.25 }
                });

            migrationBuilder.InsertData(
                table: "CoffeeCapacities",
                columns: new[] { "CapacityId", "CoffeeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 },
                    { 2, 3 },
                    { 3, 3 },
                    { 1, 4 },
                    { 2, 4 },
                    { 3, 4 },
                    { 2, 5 },
                    { 3, 5 }
                });

            migrationBuilder.InsertData(
                table: "CoffeeMilks",
                columns: new[] { "CoffeeId", "MilkId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 3 },
                    { 3, 4 },
                    { 5, 1 },
                    { 5, 2 }
                });

            migrationBuilder.InsertData(
                table: "CoffeeNonDairyAlternatives",
                columns: new[] { "CoffeeId", "NonDairyAlternativeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 3 },
                    { 5, 1 },
                    { 5, 2 }
                });

            migrationBuilder.InsertData(
                table: "CoffeeToppings",
                columns: new[] { "CoffeeId", "ToppingId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 2, 1 },
                    { 2, 3 },
                    { 3, 1 },
                    { 3, 3 },
                    { 3, 4 },
                    { 4, 3 },
                    { 5, 1 },
                    { 5, 2 }
                });

            migrationBuilder.InsertData(
                table: "CoffeeToppings",
                columns: new[] { "CoffeeId", "ToppingId" },
                values: new object[] { 5, 4 });

            migrationBuilder.InsertData(
                table: "CoffeeToppings",
                columns: new[] { "CoffeeId", "ToppingId" },
                values: new object[] { 5, 5 });

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeCapacities_Capacities_CapacityId",
                table: "CoffeeCapacities",
                column: "CapacityId",
                principalTable: "Capacities",
                principalColumn: "CapacityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeCapacities_Coffees_CoffeeId",
                table: "CoffeeCapacities",
                column: "CoffeeId",
                principalTable: "Coffees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeMilks_Coffees_CoffeeId",
                table: "CoffeeMilks",
                column: "CoffeeId",
                principalTable: "Coffees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeMilks_Milks_MilkId",
                table: "CoffeeMilks",
                column: "MilkId",
                principalTable: "Milks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeNonDairyAlternatives_Coffees_CoffeeId",
                table: "CoffeeNonDairyAlternatives",
                column: "CoffeeId",
                principalTable: "Coffees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeNonDairyAlternatives_NonDiaryAlternatives_NonDairyAlternativeId",
                table: "CoffeeNonDairyAlternatives",
                column: "NonDairyAlternativeId",
                principalTable: "NonDiaryAlternatives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeToppings_Coffees_CoffeeId",
                table: "CoffeeToppings",
                column: "CoffeeId",
                principalTable: "Coffees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeToppings_Toppings_ToppingId",
                table: "CoffeeToppings",
                column: "ToppingId",
                principalTable: "Toppings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeCapacities_Capacities_CapacityId",
                table: "CoffeeCapacities");

            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeCapacities_Coffees_CoffeeId",
                table: "CoffeeCapacities");

            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeMilks_Coffees_CoffeeId",
                table: "CoffeeMilks");

            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeMilks_Milks_MilkId",
                table: "CoffeeMilks");

            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeNonDairyAlternatives_Coffees_CoffeeId",
                table: "CoffeeNonDairyAlternatives");

            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeNonDairyAlternatives_NonDiaryAlternatives_NonDairyAlternativeId",
                table: "CoffeeNonDairyAlternatives");

            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeToppings_Coffees_CoffeeId",
                table: "CoffeeToppings");

            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeToppings_Toppings_ToppingId",
                table: "CoffeeToppings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Toppings",
                table: "Toppings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NonDiaryAlternatives",
                table: "NonDiaryAlternatives");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Milks",
                table: "Milks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoffeeToppings",
                table: "CoffeeToppings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoffeeNonDairyAlternatives",
                table: "CoffeeNonDairyAlternatives");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoffeeMilks",
                table: "CoffeeMilks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoffeeCapacities",
                table: "CoffeeCapacities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Capacities",
                table: "Capacities");

            migrationBuilder.DeleteData(
                table: "CoffeeCapacities",
                keyColumns: new[] { "CapacityId", "CoffeeId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CoffeeCapacities",
                keyColumns: new[] { "CapacityId", "CoffeeId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "CoffeeCapacities",
                keyColumns: new[] { "CapacityId", "CoffeeId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CoffeeCapacities",
                keyColumns: new[] { "CapacityId", "CoffeeId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "CoffeeCapacities",
                keyColumns: new[] { "CapacityId", "CoffeeId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "CoffeeCapacities",
                keyColumns: new[] { "CapacityId", "CoffeeId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "CoffeeCapacities",
                keyColumns: new[] { "CapacityId", "CoffeeId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "CoffeeCapacities",
                keyColumns: new[] { "CapacityId", "CoffeeId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "CoffeeCapacities",
                keyColumns: new[] { "CapacityId", "CoffeeId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "CoffeeCapacities",
                keyColumns: new[] { "CapacityId", "CoffeeId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "CoffeeCapacities",
                keyColumns: new[] { "CapacityId", "CoffeeId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "CoffeeCapacities",
                keyColumns: new[] { "CapacityId", "CoffeeId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "CoffeeMilks",
                keyColumns: new[] { "CoffeeId", "MilkId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CoffeeMilks",
                keyColumns: new[] { "CoffeeId", "MilkId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CoffeeMilks",
                keyColumns: new[] { "CoffeeId", "MilkId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "CoffeeMilks",
                keyColumns: new[] { "CoffeeId", "MilkId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "CoffeeMilks",
                keyColumns: new[] { "CoffeeId", "MilkId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "CoffeeMilks",
                keyColumns: new[] { "CoffeeId", "MilkId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "CoffeeMilks",
                keyColumns: new[] { "CoffeeId", "MilkId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "CoffeeMilks",
                keyColumns: new[] { "CoffeeId", "MilkId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "CoffeeMilks",
                keyColumns: new[] { "CoffeeId", "MilkId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "CoffeeMilks",
                keyColumns: new[] { "CoffeeId", "MilkId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "CoffeeMilks",
                keyColumns: new[] { "CoffeeId", "MilkId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "CoffeeNonDairyAlternatives",
                keyColumns: new[] { "CoffeeId", "NonDairyAlternativeId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CoffeeNonDairyAlternatives",
                keyColumns: new[] { "CoffeeId", "NonDairyAlternativeId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CoffeeNonDairyAlternatives",
                keyColumns: new[] { "CoffeeId", "NonDairyAlternativeId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "CoffeeNonDairyAlternatives",
                keyColumns: new[] { "CoffeeId", "NonDairyAlternativeId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "CoffeeNonDairyAlternatives",
                keyColumns: new[] { "CoffeeId", "NonDairyAlternativeId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "CoffeeNonDairyAlternatives",
                keyColumns: new[] { "CoffeeId", "NonDairyAlternativeId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "CoffeeNonDairyAlternatives",
                keyColumns: new[] { "CoffeeId", "NonDairyAlternativeId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "CoffeeNonDairyAlternatives",
                keyColumns: new[] { "CoffeeId", "NonDairyAlternativeId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "CoffeeNonDairyAlternatives",
                keyColumns: new[] { "CoffeeId", "NonDairyAlternativeId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "CoffeeNonDairyAlternatives",
                keyColumns: new[] { "CoffeeId", "NonDairyAlternativeId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "CoffeeSauces",
                keyColumns: new[] { "CoffeeId", "SauceId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "CoffeeToppings",
                keyColumns: new[] { "CoffeeId", "ToppingId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "CoffeeToppings",
                keyColumns: new[] { "CoffeeId", "ToppingId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "CoffeeToppings",
                keyColumns: new[] { "CoffeeId", "ToppingId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "CoffeeToppings",
                keyColumns: new[] { "CoffeeId", "ToppingId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "CoffeeToppings",
                keyColumns: new[] { "CoffeeId", "ToppingId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "CoffeeToppings",
                keyColumns: new[] { "CoffeeId", "ToppingId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "CoffeeToppings",
                keyColumns: new[] { "CoffeeId", "ToppingId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "CoffeeToppings",
                keyColumns: new[] { "CoffeeId", "ToppingId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "CoffeeToppings",
                keyColumns: new[] { "CoffeeId", "ToppingId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "CoffeeToppings",
                keyColumns: new[] { "CoffeeId", "ToppingId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "CoffeeToppings",
                keyColumns: new[] { "CoffeeId", "ToppingId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "Capacities",
                keyColumn: "CapacityId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Capacities",
                keyColumn: "CapacityId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Capacities",
                keyColumn: "CapacityId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Milks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Milks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Milks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Milks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "NonDiaryAlternatives",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "NonDiaryAlternatives",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "NonDiaryAlternatives",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.RenameTable(
                name: "Toppings",
                newName: "Topping");

            migrationBuilder.RenameTable(
                name: "NonDiaryAlternatives",
                newName: "NonDiaryAlternative");

            migrationBuilder.RenameTable(
                name: "Milks",
                newName: "Milk");

            migrationBuilder.RenameTable(
                name: "CoffeeToppings",
                newName: "CoffeeTopping");

            migrationBuilder.RenameTable(
                name: "CoffeeNonDairyAlternatives",
                newName: "CoffeeNonDairyAlternative");

            migrationBuilder.RenameTable(
                name: "CoffeeMilks",
                newName: "CoffeeMilk");

            migrationBuilder.RenameTable(
                name: "CoffeeCapacities",
                newName: "CoffeeCapacity");

            migrationBuilder.RenameTable(
                name: "Capacities",
                newName: "Capacity");

            migrationBuilder.RenameIndex(
                name: "IX_CoffeeToppings_ToppingId",
                table: "CoffeeTopping",
                newName: "IX_CoffeeTopping_ToppingId");

            migrationBuilder.RenameIndex(
                name: "IX_CoffeeNonDairyAlternatives_NonDairyAlternativeId",
                table: "CoffeeNonDairyAlternative",
                newName: "IX_CoffeeNonDairyAlternative_NonDairyAlternativeId");

            migrationBuilder.RenameIndex(
                name: "IX_CoffeeMilks_MilkId",
                table: "CoffeeMilk",
                newName: "IX_CoffeeMilk_MilkId");

            migrationBuilder.RenameIndex(
                name: "IX_CoffeeCapacities_CapacityId",
                table: "CoffeeCapacity",
                newName: "IX_CoffeeCapacity_CapacityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Topping",
                table: "Topping",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NonDiaryAlternative",
                table: "NonDiaryAlternative",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Milk",
                table: "Milk",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoffeeTopping",
                table: "CoffeeTopping",
                columns: new[] { "CoffeeId", "ToppingId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoffeeNonDairyAlternative",
                table: "CoffeeNonDairyAlternative",
                columns: new[] { "CoffeeId", "NonDairyAlternativeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoffeeMilk",
                table: "CoffeeMilk",
                columns: new[] { "CoffeeId", "MilkId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoffeeCapacity",
                table: "CoffeeCapacity",
                columns: new[] { "CoffeeId", "CapacityId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Capacity",
                table: "Capacity",
                column: "CapacityId");

            migrationBuilder.InsertData(
                table: "CoffeeSauces",
                columns: new[] { "CoffeeId", "SauceId" },
                values: new object[] { 5, 3 });

            migrationBuilder.UpdateData(
                table: "Coffees",
                keyColumn: "Id",
                keyValue: 1,
                column: "MaxAllowedToppings",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Coffees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "MaxAllowedToppings", "Name" },
                values: new object[] { "Espresso with steamed milk", 0, "Latte" });

            migrationBuilder.UpdateData(
                table: "Coffees",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "MaxAllowedToppings", "Name" },
                values: new object[] { "Espresso with steamed milk foam", 0, "Cappuccino" });

            migrationBuilder.UpdateData(
                table: "Coffees",
                keyColumn: "Id",
                keyValue: 4,
                column: "MaxAllowedToppings",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Coffees",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "MaxAllowedSauces", "MaxAllowedToppings" },
                values: new object[] { 4, 0 });

            migrationBuilder.UpdateData(
                table: "Sauces",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 0.75);

            migrationBuilder.UpdateData(
                table: "Sauces",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 0.59999999999999998);

            migrationBuilder.UpdateData(
                table: "Sauces",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Peppermint Syrup");

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeCapacity_Capacity_CapacityId",
                table: "CoffeeCapacity",
                column: "CapacityId",
                principalTable: "Capacity",
                principalColumn: "CapacityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeCapacity_Coffees_CoffeeId",
                table: "CoffeeCapacity",
                column: "CoffeeId",
                principalTable: "Coffees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeMilk_Coffees_CoffeeId",
                table: "CoffeeMilk",
                column: "CoffeeId",
                principalTable: "Coffees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeMilk_Milk_MilkId",
                table: "CoffeeMilk",
                column: "MilkId",
                principalTable: "Milk",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeNonDairyAlternative_Coffees_CoffeeId",
                table: "CoffeeNonDairyAlternative",
                column: "CoffeeId",
                principalTable: "Coffees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeNonDairyAlternative_NonDiaryAlternative_NonDairyAlternativeId",
                table: "CoffeeNonDairyAlternative",
                column: "NonDairyAlternativeId",
                principalTable: "NonDiaryAlternative",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeTopping_Coffees_CoffeeId",
                table: "CoffeeTopping",
                column: "CoffeeId",
                principalTable: "Coffees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeTopping_Topping_ToppingId",
                table: "CoffeeTopping",
                column: "ToppingId",
                principalTable: "Topping",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
