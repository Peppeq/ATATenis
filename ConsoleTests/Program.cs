using AtaTennisApp.BL.DTO;
using AtaTennisApp.BL.UserService;
using AtaTennisApp.Data;
using AtaTennisApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var connection = "Server=PCPQ\\SQLEXPRESS;Database=ATATENNIS;Trusted_Connection=True;";
            var optionsBuilder = new DbContextOptionsBuilder<AtaTennisContext>();
            optionsBuilder.UseSqlServer(connection);

            var context = new AtaTennisContext();
            DbInitializer.Initialize(context);

            var player = context.Players.FirstOrDefault();
            //player.Wait();
            //Console.WriteLine(player.Result.Age + player.Result.Name + ' ' + player.Result.Surname);
            Console.WriteLine(player.BirthDate + player.Name + ' ' + player.Surname);

            //var user = new UserDTO(){    
            //    //Email = "",
            //    Password = "admin",
            //    Username = "admin2"
            //};
            //var userService = new UserService(context);
            //Task.WaitAll(userService.CreateAsync(user));

            Console.ReadLine();

        }
    }
}
