using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtaTennisApp.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Surname = table.Column<string>(maxLength: 50, nullable: false),
                    Age = table.Column<int>(nullable: true),
                    Height = table.Column<int>(nullable: true),
                    Residence = table.Column<string>(maxLength: 50, nullable: true),
                    Forehand = table.Column<bool>(nullable: true),
                    Backhand = table.Column<bool>(nullable: true),
                    Racquet = table.Column<string>(maxLength: 30, nullable: true),
                    Surface = table.Column<int>(nullable: true),
                    FavouritePlayer = table.Column<string>(maxLength: 30, nullable: true),
                    TitlesCount = table.Column<int>(nullable: true),
                    FinalistCount = table.Column<int>(nullable: true),
                    TournamentCount = table.Column<int>(nullable: true),
                    Member = table.Column<bool>(nullable: true),
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: true),
                    Place = table.Column<string>(maxLength: 100, nullable: false),
                    Category = table.Column<int>(nullable: false),
                    PlayingSystem = table.Column<int>(nullable: false),
                    BallsType = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TournamentType = table.Column<int>(nullable: false),
                    Surface = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournament", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Draw",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<int>(nullable: false),
                    CountOfPlayers = table.Column<int>(nullable: false),
                    TournamentId = table.Column<int>(nullable: false),
                    Round = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Draw", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Draw_Tournament",
                        column: x => x.TournamentId,
                        principalTable: "Tournament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TournamentId = table.Column<int>(nullable: false),
                    Score = table.Column<int>(nullable: false),
                    Retired = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Match_Tournament",
                        column: x => x.TournamentId,
                        principalTable: "Tournament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrawMatch",
                columns: table => new
                {
                    DrawId = table.Column<int>(nullable: false),
                    MatchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DrawMatc__0696BFAF7276884F", x => new { x.DrawId, x.MatchId });
                    table.ForeignKey(
                        name: "FK_DrawMatch_Draw",
                        column: x => x.DrawId,
                        principalTable: "Draw",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DrawMatch_Match",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MatchPlayer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MatchId = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchPlayer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchPlayer_Match",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatchPlayer_Player",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "FK_Draw_Tournament",
                table: "Draw",
                column: "TournamentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DrawMatch_MatchId",
                table: "DrawMatch",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "fkIdx_Match_Tournament",
                table: "Match",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "fkIdx_MatchPlayer_Match",
                table: "MatchPlayer",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "fkIdx_MatchPlayer_Player",
                table: "MatchPlayer",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrawMatch");

            migrationBuilder.DropTable(
                name: "MatchPlayer");

            migrationBuilder.DropTable(
                name: "Draw");

            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Tournament");
        }
    }
}
