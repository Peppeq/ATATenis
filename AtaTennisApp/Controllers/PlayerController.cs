using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public PlayerController(AtaTennisContext dbContext)
        {
            _dbContext = dbContext;
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

        [HttpGet]
        public async Task<ActionResult<PlayerResponse>> Get([FromQuery]PlayerArgs args)
        {
            var response = new PlayerResponse();
            if (args.Id != null)
            {
                response.Players = await _dbContext.Player.Where(p => p.Id == args.Id).ToListAsync();
            }
            else if (args.Ranking != null && args.Ranking == true)
            {
                response.Players = await _dbContext.Player.OrderBy(p => p.Points).ToListAsync();
            }
            return response;
        }
    }
}