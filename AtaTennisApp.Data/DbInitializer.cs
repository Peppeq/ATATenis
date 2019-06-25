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
            context.SaveChanges();
        }
    }
}
