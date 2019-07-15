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

        [HttpGet]
        public async Task<ActionResult<Tournament>> Get(int id)
        {
            var response = new Tournament();
            response = await _dbContext.Tournament.Where(t=> t.Id == id).FirstOrDefaultAsync();
            if (response == null)
            {
                return NotFound();
            }
            return response;
        }
    }
}
