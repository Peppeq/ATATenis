using AtaTennisApp.Controllers.Base;
using AtaTennisApp.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtaTennisApp.Controllers
{
    [Route("api/[controller]")]
    public class TournamentController : ApiControllerBase
    {
        private AtaTennisContext _dbContext;
        public TournamentController(AtaTennisContext dbContext)
        {
            _dbContext = dbContext;
        }

        public class TournamentArgs
        {
            public int Id { get; set; }
        }

        [HttpGet]
        public async Task<ActionResult<Tournament>> Get([FromQuery]TournamentArgs args)
        {
            var response = new Tournament();
            response = await _dbContext.Tournament.Where(t=> t.Id == args.Id).FirstOrDefaultAsync();
            if (response == null)
            {
                return NotFound();
            }
            return response;
        }
    }
}
