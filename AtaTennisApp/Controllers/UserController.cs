using AtaTennisApp.BL.DTO;
using AtaTennisApp.BL.Helper;
using AtaTennisApp.BL.UserService;
using AtaTennisApp.Controllers.Base;
using AtaTennisApp.Data.Entities;
using AtaTennisApp.Helper;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AtaTennisApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : ApiControllerBase
    {
        private IUserService _userService;
        private AtaTennisContext _dbContext;
        private readonly AppSettings _appSettings;
        private IMapper _mapper;

        public UserController(AtaTennisContext dbContext, IOptions<AppSettings> appSettings)
        {
            _dbContext = dbContext;
            _userService = new UserService(_dbContext);
            _appSettings = appSettings.Value;

            _mapper = MapperHelper.GetUserMapper();
        }

        //public class AuthenticatedUser {
        //    public string UserName { get; set; }
        //    public string Token { get; set; }
        //}

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<ActionResult<UserDTO>> Authenticate([FromBody]UserDTO userDto)
        {
            var user = await _userService.AuthenticateAsync(userDto.Username, userDto.Password);
            if (user == null)
            {
                return GetErrorResponse(System.Net.HttpStatusCode.BadRequest, "Username or password is incorrect");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info (without password) and token to store client side
            return Ok(new UserDTO
            {
                Username = user.Username,
                //FirstName = user.FirstName,
                //LastName = user.LastName,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserDTO userDto)
        {
            try
            {
                // save 
                await _userService.CreateAsync(userDto);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult<IList<UserDTO>> GetAll()
        {
            var users = _userService.GetAll();
            var userDtos = _mapper.Map<IList<UserDTO>>(users);
            return Ok(userDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            var userDto = _mapper.Map<UserDTO>(user);
            return Ok(userDto);
        }

        //[HttpPost]
        //public async Task<IActionResult> Update(int id, [FromBody]UserDTO userDto)
        //{
        //    // map dto to entity and set id
        //    var user = _mapper.Map<User>(userDto);
        //    user.Id = id;

        //    try
        //    {
        //        // save 
        //        await _userService.UpdateAsync(user, userDto.Password);
        //        return Ok();
        //    }
        //    catch (AppException ex)
        //    {
        //        // return error message if there was an exception
        //        return GetErrorResponse(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        //    }
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteAsync(id);
            return Ok();
        }
    }
}
