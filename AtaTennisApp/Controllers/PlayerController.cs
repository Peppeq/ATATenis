using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtaTennisApp.BL;
using AtaTennisApp.BL.DTO;
using AtaTennisApp.Controllers.Base;
using AtaTennisApp.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Authorization;

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
            public int Id { get; set; }
        }

        public class PlayerSearchArgs
        {
            public string SearchName { get; set; }
        }

        [HttpGet("PlayersByRanking")]
        public async Task<ActionResult<List<PlayerDTO>>> GetAllPlayers()
        {
            var players = await PlayerService.GetAllPlayers();

            return players;
        }

        [HttpGet("PlayerById")]
        public async Task<ActionResult<PlayerDTO>> GetPlayerById([FromQuery]PlayerArgs args)
        {
            var player = await PlayerService.GetPlayerById(args.Id);
            return player;
        }

        [Authorize]
        [HttpPost("AddOrEditPlayer")]
        public async Task<ActionResult> AddOrEditPlayer([FromBody]PlayerDTO player)
        {
            var updatedPlayer = await PlayerService.AddOrEditPlayer(player);
            if (player.Id > 0)
            {
                return NoContent();
            }
            var uri = "api/player";
            return Created(uri, updatedPlayer);
        }

        [HttpGet("PlayerBySearch")]
        public async Task<ActionResult<List<PlayerDTO>>> PlayerBySearch([FromQuery]PlayerSearchArgs args)
        {
            var players = await PlayerService.GetPlayersByNameSurname(args.SearchName);
            return players;
        }
    }
} 