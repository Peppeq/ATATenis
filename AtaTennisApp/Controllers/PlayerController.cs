using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtaTennisApp.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtaTennisApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private AtaTennisContext _dbContext;
        public PlayerController(AtaTennisContext dbContext)
        {
            _dbContext = dbContext;
        }

        public class PlayerResponse
        {
            public List<Player> Players { get; set; }
        }

        [HttpGet]
        public async Task<PlayerResponse> Get()
        {
            var response = new PlayerResponse();
            response.Players = await _dbContext.Player.ToListAsync();
            return response;
        }
    }
}