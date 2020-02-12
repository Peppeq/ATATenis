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
        private TournamentService TournamentService { get; set; }

        public class SearchedTournamentByNameArgs
        {
            public string Name { get; set; }
        }

        public TournamentController(AtaTennisContext dbContext)
        {
            _dbContext = dbContext;
            TournamentService = new TournamentService(dbContext);
        }

        public class TournamentPlayersArgs
        {
            public int TournamentId { get; set; }
        }

        [HttpGet]
        public async Task<ActionResult<List<TournamentDTO>>> Get([FromQuery]TournamentFilter args)
        {
            var service = new TournamentService(_dbContext);
            List<TournamentDTO> response = await service.GetFilteredTournaments(args);
            return response;
        }

        [HttpGet("GetSearchedTournamentsByName")]
        public async Task<ActionResult<List<SearchedTournamentDTO>>> GetSearchedTournamentsByName([FromQuery]SearchedTournamentByNameArgs args)
        {
            List<SearchedTournamentDTO> response = await TournamentService.GetSearchedTournamentsByName(args.Name);
            return response;
        }

        [HttpGet("GetTournamentPlayers")]
        public async Task<ActionResult<TournamentGraphDTO>> GetTournamentPlayers([FromQuery]TournamentPlayersArgs args)
        {
            var response = await TournamentService.GetTournamentGraph(args.TournamentId);
            if (response == null)
            {
                return NotFound();
            }
            return response;
        }

        [HttpGet("nearestTournament")]
        public async Task<ActionResult<TournamentDTO>> GetNearestTournament()
        {
            var service = new TournamentService(_dbContext);
            return await service.GetNearestTournament();
        }

        [Authorize]
        [HttpPost("AddOrEditTournament")]
        public async Task<ActionResult<TournamentDTO>> AddOrEditTournament([FromBody] TournamentDTO tournamentDto)
        {
            var updatedTournament = await TournamentService.AddOrEditTournament(tournamentDto);
            if (tournamentDto.Id > 0)
            {
                return NoContent();
            }
            var uri = "api/tournament";
            return Created(uri, updatedTournament);
        }
    }
}
