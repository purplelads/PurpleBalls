using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PurpleBalls.Data.Migrations
{
    public partial class PlayerShirts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerShirts",
                columns: table => new
                {
                    PlayerShirtId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ShirtName = table.Column<string>(nullable: true),
                    ShirtNumber = table.Column<int>(nullable: false),
                    ShirtStyle = table.Column<int>(nullable: false),
                    ShirtPrimary = table.Column<string>(nullable: true),
                    ShirtSecondary = table.Column<string>(nullable: true),
                    PlayerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerShirts", x => x.PlayerShirtId);
                    table.ForeignKey(
                        name: "FK_PlayerShirts_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerShirts_PlayerId",
                table: "PlayerShirts",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerShirts");
        }
    }
}
