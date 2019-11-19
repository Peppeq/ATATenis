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
            if (context.Players.Any() && context.Tournaments.Any() && context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var players = new Player[]
            {
                new Player{BirthDate= new DateTime(1988, 5,5), Name = "Peter", Surname = "Sveter", Points = 450,
                    Backhand = Backhand.oneHanded, FavouritePlayer = "Roger", Forehand = Forehand.rightHanded,
                    Height = 175, Weight = 70, Racquet = "Wilson Blade", Residence = "Spisska Nova Ves" , Surface = SurfaceType.clay },
                new Player{BirthDate=new DateTime(1994, 3,8), Name = "Jano", Surname = "Slany", Points = 50,
                    Backhand = Backhand.twoHanded, FavouritePlayer = "Delpo", Forehand = Forehand.rightHanded,
                    Height = 185, Weight= 78, Racquet = "Babolat", Residence = "Nitra" , Surface = SurfaceType.grass },
                new Player{BirthDate=new DateTime(1978,4,7), Name = "Miso", Surname = "Sef", Points = 220,
                Backhand = Backhand.twoHanded, FavouritePlayer = "Rafa", Forehand = Forehand.rightHanded,
                    Height = 181,Weight= 82, Racquet = "Babolat", Residence = "Blava" , Surface = SurfaceType.grass },
                new Player{BirthDate=new DateTime(1969, 2,2), Name = "Jozo", Surname = "Suly", Points = 185,
                Backhand = Backhand.twoHanded, FavouritePlayer = "Delpo", Forehand = Forehand.rightHanded,
                    Height = 185,Weight= 96, Racquet = "Babolat", Residence = "Nitra" , Surface = SurfaceType.grass },
            };

            foreach (Player p in players)
            {
                context.Players.Add(p);
            }

            if (context.Tournaments.Any())
            {
                return;
            }

            var tournaments = new Tournament[]
            {
                new Tournament{
                    Category = TournamentCategory.singles,
                    BallsType = BallsType.slazenger,
                    Description = "wimbledon summer challange dufajme za pekneho letneho pocasia...",
                    DrawType = DrawType.playoff,
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
                    DrawType = DrawType.playoff,
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
                    DrawType = DrawType.playoff,
                    Name = "Senica OPEN",
                    Place = "Senica",
                    PlayingSystem = PlayingSystem.prince,
                    TournamentType = TournamentType.ata,
                    StartTime = new DateTime(2019,8,2),
                    EndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 3),
                    Surface = SurfaceType.clay
                },
                new Tournament{
                    Category = TournamentCategory.singles,
                    BallsType = BallsType.dunlop,
                    Description = "wimbledon summer challange dufajme za pekneho letneho pocasia...",
                    DrawType = DrawType.playoff,
                    Name = "Summer Cup Open",
                    Place = "Břeclav",
                    PlayingSystem = PlayingSystem.prince,
                    TournamentType = TournamentType.challanger,
                    StartTime = new DateTime(2019,9,12),
                    EndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 13),
                    Surface = SurfaceType.clay
                }
            };

            foreach (var tournament in tournaments)
            {
                context.Tournaments.Add(tournament);
            }

            if (context.Users.Any())
            {
                return;
            }

            var admin = new User { Username = "admin", Password = "AXFiT5iav+brOl0kBp9nkaHpMku/Tdh9xKdrY1uecawhNSBrIQfzEzW6uw==", Email = "" };

            context.Users.Add(admin);

            context.SaveChanges();
        }
    }
}
