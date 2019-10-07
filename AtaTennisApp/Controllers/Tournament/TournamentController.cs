using AtaTennisApp.BL;
using AtaTennisApp.BL.DTO;
using AtaTennisApp.Controllers.Base;
using AtaTennisApp.Data;
using AtaTennisApp.Data.Entities;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<ActionResult<List<TournamentDTO>>> Get([FromQuery]TournamentFilter args)
        {
            var service = new TournamentService(_dbContext);
            List<TournamentDTO> response = await service.GetFilteredTournaments(args);
            return response;
        }

        [HttpGet("nearestTournament")]
        public async Task<ActionResult<TournamentDTO>> GetNearestTournament()
        {
            var service = new TournamentService(_dbContext);
            return await service.GetNearestTournament();
        }

    }
}
