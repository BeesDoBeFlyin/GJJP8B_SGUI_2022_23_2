using Microsoft.EntityFrameworkCore.Migrations;

namespace GJJP8B_HFT_2021221.Data.Migrations
{
    public partial class SeedMilksTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_buyers_cheeses_CheeseId",
                table: "buyers");

            migrationBuilder.DropForeignKey(
                name: "FK_cheeses_milks_MilkId",
                table: "cheeses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_milks",
                table: "milks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cheeses",
                table: "cheeses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_buyers",
                table: "buyers");

            migrationBuilder.RenameTable(
                name: "milks",
                newName: "Milks");

            migrationBuilder.RenameTable(
                name: "cheeses",
                newName: "Cheeses");

            migrationBuilder.RenameTable(
                name: "buyers",
                newName: "Buyers");

            migrationBuilder.RenameIndex(
                name: "IX_cheeses_MilkId",
                table: "Cheeses",
                newName: "IX_Cheeses_MilkId");

            migrationBuilder.RenameIndex(
                name: "IX_buyers_CheeseId",
                table: "Buyers",
                newName: "IX_Buyers_CheeseId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Milks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cheeses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Milks",
                table: "Milks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cheeses",
                table: "Cheeses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buyers",
                table: "Buyers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Buyers_Cheeses_CheeseId",
                table: "Buyers",
                column: "CheeseId",
                principalTable: "Cheeses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cheeses_Milks_MilkId",
                table: "Cheeses",
                column: "MilkId",
                principalTable: "Milks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buyers_Cheeses_CheeseId",
                table: "Buyers");

            migrationBuilder.DropForeignKey(
                name: "FK_Cheeses_Milks_MilkId",
                table: "Cheeses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Milks",
                table: "Milks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cheeses",
                table: "Cheeses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Buyers",
                table: "Buyers");

            migrationBuilder.RenameTable(
                name: "Milks",
                newName: "milks");

            migrationBuilder.RenameTable(
                name: "Cheeses",
                newName: "cheeses");

            migrationBuilder.RenameTable(
                name: "Buyers",
                newName: "buyers");

            migrationBuilder.RenameIndex(
                name: "IX_Cheeses_MilkId",
                table: "cheeses",
                newName: "IX_cheeses_MilkId");

            migrationBuilder.RenameIndex(
                name: "IX_Buyers_CheeseId",
                table: "buyers",
                newName: "IX_buyers_CheeseId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "milks",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "cheeses",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_milks",
                table: "milks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cheeses",
                table: "cheeses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_buyers",
                table: "buyers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_buyers_cheeses_CheeseId",
                table: "buyers",
                column: "CheeseId",
                principalTable: "cheeses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_cheeses_milks_MilkId",
                table: "cheeses",
                column: "MilkId",
                principalTable: "milks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
