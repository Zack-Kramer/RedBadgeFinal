using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.Data.Migrations
{
    public partial class users02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "CardBases",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CardBases_UserId",
                table: "CardBases",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CardBases_Users_UserId",
                table: "CardBases",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardBases_Users_UserId",
                table: "CardBases");

            migrationBuilder.DropIndex(
                name: "IX_CardBases_UserId",
                table: "CardBases");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CardBases");
        }
    }
}
