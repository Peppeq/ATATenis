using AtaTennisApp.BL.DTO;
using AtaTennisApp.BL.Helper;
using AtaTennisApp.BL.Helper.Mapper;
using AtaTennisApp.BL.Utils;
using AtaTennisApp.Data.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Authorization;

namespace AtaTennisApp.BL.UserService
{
    public interface IUserService
    {
        Task<UserDTO> AuthenticateAsync(string username, string password);
        IEnumerable<User> GetAll();
        Task<User> GetByIdAsync(int id);
        Task<User> CreateAsync(UserDTO userDto);
        Task UpdateAsync(User user, string password = null);
        Task DeleteAsync(int id);
    }

    public class UserService : IUserService
    {
        private readonly AtaTennisContext dbContext;
        
        private readonly IJwtUtils _jwtUtils;



        public UserService(AtaTennisContext context, IJwtUtils jwtUtils)
        {
            dbContext = context;
            _jwtUtils = jwtUtils;
        }

        public async Task<User> CreateAsync(UserDTO userDto)
        {
            // validation
            if (string.IsNullOrWhiteSpace(userDto.Password))
                throw new AppException("Password is required");

            if (dbContext.Users.Any(u => u.Username == userDto.Username))
                throw new AppException("Username \"" + userDto.Username + "\" is already taken");

            var passwordHasher = new PasswordHasher();
            var hash = passwordHasher.HashPassword(userDto.Password);

            userDto.Password = hash;

            var mapper = MapperHelper.GetUserMapper();
            var userModel = mapper.Map<UserDTO, User>(userDto);

            await dbContext.Users.AddAsync(userModel);
            await dbContext.SaveChangesAsync();

            return userModel;
        }

        public async Task<UserDTO> AuthenticateAsync(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = await dbContext.Users.SingleOrDefaultAsync(u => u.Username == username);

            if (user == null)
                return null;

            var passwordHasher = new PasswordHasher();
            var verification = passwordHasher.VerifyHashedPassword(user.Password, password);

            if (verification != Microsoft.AspNet.Identity.PasswordVerificationResult.Success)
            {
                return null;
            }

            // authentication successful so generate jwt token
            var token = _jwtUtils.GenerateJwtToken(user);

            var userDto = UserMapper.MapToDTO(user);
            userDto.Token = token;

            return userDto;
        }

        public IEnumerable<User> GetAll()
        {
            return dbContext.Users;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await dbContext.Users.FindAsync(id);
        }

        public async Task UpdateAsync(User userParam, string password = null)
        {
            var user = await dbContext.Users.FindAsync(userParam.Id);

            if(user == null)
                throw new AppException("User not found");

            if (userParam.Username != user.Username)
            {
                // username has changed so check if the new username is already taken
                if (dbContext.Users.Any(x => x.Username == userParam.Username))
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

            dbContext.Users.Update(user);
            dbContext.SaveChanges();

        }

        public async Task DeleteAsync(int id)
        {
            var user = await dbContext.Users.FindAsync(id);
            if (user != null)
            {
                dbContext.Users.Remove(user);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
