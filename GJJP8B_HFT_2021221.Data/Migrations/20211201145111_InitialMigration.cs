using Microsoft.EntityFrameworkCore.Migrations;

namespace GJJP8B_HFT_2021221.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "milks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_milks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cheeses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    MilkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cheeses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cheeses_milks_MilkId",
                        column: x => x.MilkId,
                        principalTable: "milks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "buyers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Money = table.Column<int>(type: "int", nullable: false),
                    CheeseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buyers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_buyers_cheeses_CheeseId",
                        column: x => x.CheeseId,
                        principalTable: "cheeses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "milks",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { 1, "CowMilk", 250f });

            migrationBuilder.InsertData(
                table: "milks",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { 2, "GoatMilk", 550f });

            migrationBuilder.InsertData(
                table: "cheeses",
                columns: new[] { "Id", "MilkId", "Name", "Price" },
                values: new object[] { 1, 1, "Cheddar", 1500f });

            migrationBuilder.InsertData(
                table: "cheeses",
                columns: new[] { "Id", "MilkId", "Name", "Price" },
                values: new object[] { 3, 1, "Maci", 850f });

            migrationBuilder.InsertData(
                table: "cheeses",
                columns: new[] { "Id", "MilkId", "Name", "Price" },
                values: new object[] { 2, 2, "GoatCheese", 3500f });

            migrationBuilder.InsertData(
                table: "buyers",
                columns: new[] { "Id", "CheeseId", "Money", "Name" },
                values: new object[] { 1, 1, 5500, "Test Ferenc" });

            migrationBuilder.InsertData(
                table: "buyers",
                columns: new[] { "Id", "CheeseId", "Money", "Name" },
                values: new object[] { 3, 3, 6500, "Sigh Kyle" });

            migrationBuilder.InsertData(
                table: "buyers",
                columns: new[] { "Id", "CheeseId", "Money", "Name" },
                values: new object[] { 2, 2, 9800, "Teás K. Anna" });

            migrationBuilder.CreateIndex(
                name: "IX_buyers_CheeseId",
                table: "buyers",
                column: "CheeseId");

            migrationBuilder.CreateIndex(
                name: "IX_cheeses_MilkId",
                table: "cheeses",
                column: "MilkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "buyers");

            migrationBuilder.DropTable(
                name: "cheeses");

            migrationBuilder.DropTable(
                name: "milks");
        }
    }
}
