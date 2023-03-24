using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class OneToManyCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "FootballPlayers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FootballPlayers_TeamId",
                table: "FootballPlayers",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_FootballPlayers_FootballTeams_TeamId",
                table: "FootballPlayers",
                column: "TeamId",
                principalTable: "FootballTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FootballPlayers_FootballTeams_TeamId",
                table: "FootballPlayers");

            migrationBuilder.DropIndex(
                name: "IX_FootballPlayers_TeamId",
                table: "FootballPlayers");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "FootballPlayers");
        }
    }
}
