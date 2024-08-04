using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeStoreManagementApp.Migrations
{
    public partial class fourteen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeNonDairyAlternatives_Coffees_CoffeeId",
                table: "CoffeeNonDairyAlternatives");

            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeNonDairyAlternatives_NonDiaryAlternatives_NonDairyAlternativeId",
                table: "CoffeeNonDairyAlternatives");

            migrationBuilder.DropTable(
                name: "NonDiaryAlternatives");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoffeeNonDairyAlternatives",
                table: "CoffeeNonDairyAlternatives");

            migrationBuilder.RenameTable(
                name: "CoffeeNonDairyAlternatives",
                newName: "CoffeeNonDairyAlternative");

            migrationBuilder.RenameIndex(
                name: "IX_CoffeeNonDairyAlternatives_NonDairyAlternativeId",
                table: "CoffeeNonDairyAlternative",
                newName: "IX_CoffeeNonDairyAlternative_NonDairyAlternativeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoffeeNonDairyAlternative",
                table: "CoffeeNonDairyAlternative",
                columns: new[] { "CoffeeId", "NonDairyAlternativeId" });

            migrationBuilder.CreateTable(
                name: "NonDairyAlternative",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonDairyAlternative", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "NonDairyAlternative",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { 1, "Soy Milk", 0.75 });

            migrationBuilder.InsertData(
                table: "NonDairyAlternative",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { 2, "Almond Milk", 0.75 });

            migrationBuilder.InsertData(
                table: "NonDairyAlternative",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { 3, "Oat Milk", 0.75 });

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeNonDairyAlternative_Coffees_CoffeeId",
                table: "CoffeeNonDairyAlternative",
                column: "CoffeeId",
                principalTable: "Coffees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeNonDairyAlternative_NonDairyAlternative_NonDairyAlternativeId",
                table: "CoffeeNonDairyAlternative",
                column: "NonDairyAlternativeId",
                principalTable: "NonDairyAlternative",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeNonDairyAlternative_Coffees_CoffeeId",
                table: "CoffeeNonDairyAlternative");

            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeNonDairyAlternative_NonDairyAlternative_NonDairyAlternativeId",
                table: "CoffeeNonDairyAlternative");

            migrationBuilder.DropTable(
                name: "NonDairyAlternative");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoffeeNonDairyAlternative",
                table: "CoffeeNonDairyAlternative");

            migrationBuilder.RenameTable(
                name: "CoffeeNonDairyAlternative",
                newName: "CoffeeNonDairyAlternatives");

            migrationBuilder.RenameIndex(
                name: "IX_CoffeeNonDairyAlternative_NonDairyAlternativeId",
                table: "CoffeeNonDairyAlternatives",
                newName: "IX_CoffeeNonDairyAlternatives_NonDairyAlternativeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoffeeNonDairyAlternatives",
                table: "CoffeeNonDairyAlternatives",
                columns: new[] { "CoffeeId", "NonDairyAlternativeId" });

            migrationBuilder.CreateTable(
                name: "NonDiaryAlternatives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonDiaryAlternatives", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "NonDiaryAlternatives",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { 1, "Soy Milk", 0.75 });

            migrationBuilder.InsertData(
                table: "NonDiaryAlternatives",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { 2, "Almond Milk", 0.75 });

            migrationBuilder.InsertData(
                table: "NonDiaryAlternatives",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { 3, "Oat Milk", 0.75 });

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
        }
    }
}
