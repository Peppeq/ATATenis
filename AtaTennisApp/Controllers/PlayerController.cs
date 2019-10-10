using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtaTennisApp.BL;
using AtaTennisApp.BL.DTO;
using AtaTennisApp.Controllers.Base;
using AtaTennisApp.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtaTennisApp.Controllers
{
    [Route("api/[controller]")]
    public class PlayerController : ApiControllerBase
    {
        private AtaTennisContext _dbContext;

        public PlayerService PlayerService{ get; set; }
        public PlayerController(AtaTennisContext dbContext)
        {
            _dbContext = dbContext;
            PlayerService = new PlayerService(_dbContext);
        }

        public class PlayerArgs
        {
            public int? Id { get; set; }
            public int? Count { get; set; }
            public bool? Ranking { get; set; }
        }
        public class PlayerResponse
        {
            public List<Player> Players { get; set; }
        }

        [HttpGet("PlayersByRanking")]
        public async Task<ActionResult<List<PlayerDTO>>> GetAllPlayers()
        {
            var players = await PlayerService.GetAllPlayers();
            return players;
        }

        [HttpGet("PlayerById")]
        public async Task<ActionResult<PlayerDTO>> GetPlayerById(PlayerArgs id)
        {
            var player = await PlayerService.GetPlayerById(id);
            return player;
        }
    }
}