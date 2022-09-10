using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.Data.Migrations
{
    public partial class CardBases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_LandTables_LandTableId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "CardTables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LandTables",
                table: "LandTables");

            migrationBuilder.RenameTable(
                name: "LandTables",
                newName: "CardBases");

            migrationBuilder.AlterColumn<int>(
                name: "Mana",
                table: "CardBases",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CreatureId",
                table: "CardBases",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "CardBases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "CardBases",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardBases",
                table: "CardBases",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CardBases_CreatureId",
                table: "CardBases",
                column: "CreatureId");

            migrationBuilder.CreateIndex(
                name: "IX_CardBases_UserId",
                table: "CardBases",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CardBases_Creatures_CreatureId",
                table: "CardBases",
                column: "CreatureId",
                principalTable: "Creatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CardBases_Users_UserId",
                table: "CardBases",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_CardBases_LandTableId",
                table: "Users",
                column: "LandTableId",
                principalTable: "CardBases",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardBases_Creatures_CreatureId",
                table: "CardBases");

            migrationBuilder.DropForeignKey(
                name: "FK_CardBases_Users_UserId",
                table: "CardBases");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_CardBases_LandTableId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardBases",
                table: "CardBases");

            migrationBuilder.DropIndex(
                name: "IX_CardBases_CreatureId",
                table: "CardBases");

            migrationBuilder.DropIndex(
                name: "IX_CardBases_UserId",
                table: "CardBases");

            migrationBuilder.DropColumn(
                name: "CreatureId",
                table: "CardBases");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "CardBases");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CardBases");

            migrationBuilder.RenameTable(
                name: "CardBases",
                newName: "LandTables");

            migrationBuilder.AlterColumn<int>(
                name: "Mana",
                table: "LandTables",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LandTables",
                table: "LandTables",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CardTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatureId = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    Effect = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rarity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardTables_Creatures_CreatureId",
                        column: x => x.CreatureId,
                        principalTable: "Creatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardTables_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardTables_CreatureId",
                table: "CardTables",
                column: "CreatureId");

            migrationBuilder.CreateIndex(
                name: "IX_CardTables_UserId",
                table: "CardTables",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_LandTables_LandTableId",
                table: "Users",
                column: "LandTableId",
                principalTable: "LandTables",
                principalColumn: "Id");
        }
    }
}
