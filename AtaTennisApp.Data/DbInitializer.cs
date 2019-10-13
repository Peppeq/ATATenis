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
            if (context.Player.Any() && context.Tournament.Any() && context.User.Any())
            {
                return;   // DB has been seeded
            }

            var players = new Player[]
            {
                new Player{Age=33, Name = "Peter", Surname = "Sveter", Points = 450,
                    Backhand = Backhand.oneHanded, FavouritePlayer = "Roger", Forehand = Forehand.rightHanded,
                    Height = 175, Racquet = "Wilson Blade", Residence = "Spisska Nova Ves" , Surface = SurfaceType.clay },
                new Player{Age=33, Name = "Jano", Surname = "Slany", Points = 50,
                    Backhand = Backhand.twoHanded, FavouritePlayer = "Delpo", Forehand = Forehand.rightHanded,
                    Height = 185, Racquet = "Babolat", Residence = "Nitra" , Surface = SurfaceType.grass },
                new Player{Age=39, Name = "Miso", Surname = "Sef", Points = 220,
                Backhand = Backhand.twoHanded, FavouritePlayer = "Rafa", Forehand = Forehand.rightHanded,
                    Height = 181, Racquet = "Babolat", Residence = "Blava" , Surface = SurfaceType.grass },
                new Player{Age=55, Name = "Jozo", Surname = "Suly", Points = 185,
                Backhand = Backhand.twoHanded, FavouritePlayer = "Delpo", Forehand = Forehand.rightHanded,
                    Height = 185, Racquet = "Babolat", Residence = "Nitra" , Surface = SurfaceType.grass },
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
                    StartTime = new DateTime(2019,7,12),
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
                    StartTime = new DateTime(2019,1,19),
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
                    StartTime = new DateTime(2019,8,2),
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
                    StartTime = new DateTime(2019,9,12),
                    EndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1),
                    Surface = SurfaceType.clay
                }
            };

            foreach (var tournament in tournaments)
            {
                context.Tournament.Add(tournament);
            }

            if (context.User.Any())
            {
                return;
            }

            var admin = new User { Username = "admin", Password = "AXFiT5iav+brOl0kBp9nkaHpMku/Tdh9xKdrY1uecawhNSBrIQfzEzW6uw==", Email = "" };

            context.User.Add(admin);

            context.SaveChanges();
        }
    }
}
