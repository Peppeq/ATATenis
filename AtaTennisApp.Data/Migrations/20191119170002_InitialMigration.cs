using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtaTennisApp.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Surname = table.Column<string>(maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "Date", nullable: true),
                    Height = table.Column<int>(nullable: true),
                    Weight = table.Column<int>(nullable: true),
                    Residence = table.Column<string>(maxLength: 50, nullable: true),
                    Forehand = table.Column<int>(nullable: true),
                    Backhand = table.Column<int>(nullable: true),
                    Racquet = table.Column<string>(maxLength: 30, nullable: true),
                    Surface = table.Column<int>(nullable: true),
                    FavouritePlayer = table.Column<string>(maxLength: 30, nullable: true),
                    Member = table.Column<bool>(nullable: false),
                    Points = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tournament",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    Place = table.Column<string>(maxLength: 100, nullable: false),
                    Category = table.Column<int>(nullable: false),
                    PlayingSystem = table.Column<int>(nullable: false),
                    BallsType = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TournamentType = table.Column<int>(nullable: false),
                    Surface = table.Column<int>(nullable: false),
                    DrawType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournament", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(maxLength: 75, nullable: false),
                    Password = table.Column<string>(unicode: false, maxLength: 64, nullable: false),
                    Email = table.Column<string>(maxLength: 75, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Round = table.Column<int>(nullable: false),
                    Winner = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Match_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TournamentEntry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentId = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TournamentEntry_Player",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TournamentEntry_Tournament",
                        column: x => x.TournamentId,
                        principalTable: "Tournament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MatchEntry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchId = table.Column<int>(nullable: false),
                    ParentMatchId = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchEntry_Match",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatchEntry_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Score",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SetNumber = table.Column<int>(nullable: false),
                    GamesWon = table.Column<int>(nullable: false),
                    MatchEntryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Score", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Score_MatchEntry",
                        column: x => x.MatchEntryId,
                        principalTable: "MatchEntry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Match_PlayerId",
                table: "Match",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchEntry_MatchId",
                table: "MatchEntry",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchEntry_PlayerId",
                table: "MatchEntry",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Score_MatchEntryId",
                table: "Score",
                column: "MatchEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentEntry_PlayerId",
                table: "TournamentEntry",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentEntry_TournamentId",
                table: "TournamentEntry",
                column: "TournamentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Score");

            migrationBuilder.DropTable(
                name: "TournamentEntry");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "MatchEntry");

            migrationBuilder.DropTable(
                name: "Tournament");

            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "Player");
        }
    }
}
