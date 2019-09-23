using AtaTennisApp.BL.DTO;
using AtaTennisApp.BL.Helper;
using AtaTennisApp.BL.Utils;
using AtaTennisApp.Data.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtaTennisApp.BL.UserService
{
    public interface IUserService
    {
        Task<User> AuthenticateAsync(string username, string password);
        IEnumerable<User> GetAll();
        Task<User> GetByIdAsync(int id);
        Task<User> CreateAsync(UserDTO userDto);
        Task UpdateAsync(User user, string password = null);
        Task DeleteAsync(int id);
    }

    public class UserService : IUserService
    {
        private AtaTennisContext dbContext { get; set; }
        public UserService(AtaTennisContext context)
        {
            dbContext = context;
        }

        public async Task<User> CreateAsync(UserDTO userDto)
        {
            // validation
            if (string.IsNullOrWhiteSpace(userDto.Password))
                throw new AppException("Password is required");

            if (dbContext.User.Any(u => u.Username == userDto.Username))
                throw new AppException("Username \"" + userDto.Username + "\" is already taken");

            var passwordHasher = new PasswordHasher();
            var hash = passwordHasher.HashPassword(userDto.Password);

            userDto.Password = hash;

            var mapper = MapperHelper.GetUserMapper();
            var userModel = mapper.Map<UserDTO, User>(userDto);

            await dbContext.User.AddAsync(userModel);
            await dbContext.SaveChangesAsync();

            return userModel;
        }

        public async Task<User> AuthenticateAsync(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = await dbContext.User.SingleOrDefaultAsync(u => u.Username == username);

            if (user == null)
                return null;

            var passwordHasher = new PasswordHasher();
            var verification = passwordHasher.VerifyHashedPassword(user.Password, password);

            if (verification != Microsoft.AspNetCore.Identity.PasswordVerificationResult.Success)
            {
                return null;
            }
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            return dbContext.User;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await dbContext.User.FindAsync(id);
        }

        public async Task UpdateAsync(User userParam, string password = null)
        {
            var user = await dbContext.User.FindAsync(userParam.Id);

            if(user == null)
                throw new AppException("User not found");

            if (userParam.Username != user.Username)
            {
                // username has changed so check if the new username is already taken
                if (dbContext.User.Any(x => x.Username == userParam.Username))
                    throw new AppException("Username " + userParam.Username + " is already taken");
            }

            // update user properties
            //user.FirstName = userParam.FirstName;
            //user.LastName = userParam.LastName;
            user.Username = userParam.Username;

            // update password if it was entered
            if (!string.IsNullOrWhiteSpace(password))
            {
                var passwordHasher = new PasswordHasher();
                var hash = passwordHasher.HashPassword(password);

                user.Password = hash;
            }

            dbContext.User.Update(user);
            dbContext.SaveChanges();

        }

        public async Task DeleteAsync(int id)
        {
            var user = await dbContext.User.FindAsync(id);
            if (user != null)
            {
                dbContext.User.Remove(user);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
