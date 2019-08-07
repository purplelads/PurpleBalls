using Microsoft.EntityFrameworkCore.Migrations;

namespace PurpleBalls.Data.Migrations
{
    public partial class PlayerShirts_AddColumn_TextColour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TextColour",
                table: "PlayerShirts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TextColour",
                table: "PlayerShirts");
        }
    }
}
