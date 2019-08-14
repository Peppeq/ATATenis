using AtaTennisApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtaTennisApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AtaTennisContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Player.Any())
            {
                return;   // DB has been seeded
            }

            var players = new Player[]
            {
                new Player{Age=33, Name = "Peter", Surname = "Sveter"},
                new Player{Age=33, Name = "Jano", Surname = "Slany"},
                new Player{Age=39, Name = "Miso", Surname = "Sef"},
                new Player{Age=55, Name = "Jozo", Surname = "Suly"},
            };

            foreach (Player p in players)
            {
                context.Player.Add(p);
            }

            if (context.Tournament.Any())
            {
                return;
            }

            var tournaments = new Tournament[]
            {
                new Tournament{
                    Category = TournamentCategory.singles,
                    BallsType = BallsType.slazenger,
                    Description = "wimbledon summer challange dufajme za pekneho letneho pocasia...",
                    Draw = new Draw{
                        CountOfPlayers = 16,
                        Round = 1,
                        Type = DrawType.playoff
                    },
                    Name = "Wimbledon Challange",
                    Place = "Kopčany",
                    PlayingSystem = PlayingSystem.prince,
                    TournamentType = TournamentType.challangerSpecial,
                    StartTime = DateTime.Now,
                    Surface = SurfaceType.grass
                },
                new Tournament{
                    Category = TournamentCategory.singles,
                    BallsType = BallsType.dunlop,
                    Description = "Areal nitrianskeho futbaloveho stadiona",
                    Draw = new Draw{
                        CountOfPlayers = 19,
                        Round = 1,
                        Type = DrawType.playoff
                    },
                    Name = "Temprim CUP",
                    Place = "Nitra",
                    PlayingSystem = PlayingSystem.prince,
                    TournamentType = TournamentType.challanger,
                    StartTime = DateTime.Now,
                    Surface = SurfaceType.clay
                },
                new Tournament{
                    Category = TournamentCategory.singles,
                    BallsType = BallsType.slazenger,
                    Description = "wimbledon summer challange dufajme za pekneho letneho pocasia...",
                    Draw = new Draw{
                        CountOfPlayers = 16,
                        Round = 1,
                        Type = DrawType.playoff
                    },
                    Name = "Senica OPEN",
                    Place = "Senica",
                    PlayingSystem = PlayingSystem.prince,
                    TournamentType = TournamentType.ata,
                    StartTime = DateTime.Now,
                    EndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1),
                    Surface = SurfaceType.clay
                },
                new Tournament{
                    Category = TournamentCategory.singles,
                    BallsType = BallsType.dunlop,
                    Description = "wimbledon summer challange dufajme za pekneho letneho pocasia...",
                    Draw = new Draw{
                        CountOfPlayers = 16,
                        Round = 1,
                        Type = DrawType.playoff
                    },
                    Name = "Summer Cup Open",
                    Place = "Břeclav",
                    PlayingSystem = PlayingSystem.prince,
                    TournamentType = TournamentType.challanger,
                    StartTime = DateTime.Now,
                    EndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1),
                    Surface = SurfaceType.clay
                }
            };

            foreach (var tournament in tournaments)
            {
                context.Tournament.Add(tournament);
            }

            context.SaveChanges();
        }
    }
}
