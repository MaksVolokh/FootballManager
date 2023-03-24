using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class OneToManyUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FootballPlayers_FootballTeams_TeamId",
                table: "FootballPlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_FootballTeams_CoachForTeam_CoachId",
                table: "FootballTeams");

            migrationBuilder.DropIndex(
                name: "IX_FootballTeams_CoachId",
                table: "FootballTeams");

            migrationBuilder.AlterColumn<int>(
                name: "CoachId",
                table: "FootballTeams",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "FootballPlayers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_FootballTeams_CoachId",
                table: "FootballTeams",
                column: "CoachId",
                unique: true,
                filter: "[CoachId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_FootballPlayers_FootballTeams_TeamId",
                table: "FootballPlayers",
                column: "TeamId",
                principalTable: "FootballTeams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FootballTeams_CoachForTeam_CoachId",
                table: "FootballTeams",
                column: "CoachId",
                principalTable: "CoachForTeam",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FootballPlayers_FootballTeams_TeamId",
                table: "FootballPlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_FootballTeams_CoachForTeam_CoachId",
                table: "FootballTeams");

            migrationBuilder.DropIndex(
                name: "IX_FootballTeams_CoachId",
                table: "FootballTeams");

            migrationBuilder.AlterColumn<int>(
                name: "CoachId",
                table: "FootballTeams",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "FootballPlayers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FootballTeams_CoachId",
                table: "FootballTeams",
                column: "CoachId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FootballPlayers_FootballTeams_TeamId",
                table: "FootballPlayers",
                column: "TeamId",
                principalTable: "FootballTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FootballTeams_CoachForTeam_CoachId",
                table: "FootballTeams",
                column: "CoachId",
                principalTable: "CoachForTeam",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
