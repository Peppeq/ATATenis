using AtaTennisApp.BL;
using AtaTennisApp.BL.DTO;
using AtaTennisApp.Controllers.Base;
using AtaTennisApp.Data.Entities;
//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtaTennisApp.Controllers
{
    [Route("api/[controller]")]
    public class TournamentEntryController : ApiControllerBase
    {
        private AtaTennisContext _dbContext;

        public TournamentEntryService TournamentEntryService { get; set; }
        public TournamentEntryController(AtaTennisContext dbContext)
        {
            _dbContext = dbContext;
            TournamentEntryService = new TournamentEntryService(_dbContext);
        }

        public class GetPlayersArgs
        {
            public int TournamentId { get; set; }
        }

        public class GetSearchedPlayersArgs
        {
            public string NameSurname { get; set; }
        }

        public class PlayerArgs
        {
            public int TournamentId { get; set; }
            public int PlayerId { get; set; }
        }

        public class DeletePlayerArgs
        {
            public int TournamentEntryId { get; set; }
        }

        [HttpGet("TournamentPlayers")]
        public async Task<ActionResult<List<PlayerDrawDTO>>> TournamentPlayers([FromQuery]GetPlayersArgs args)
        {
            var players = await TournamentEntryService.GetTournamentPlayers(args.TournamentId);
            return players;
        }

        [HttpGet("GetSearchedPlayers")]
        public async Task<ActionResult<List<PlayerDrawDTO>>> GetSearchedPlayers([FromQuery]GetSearchedPlayersArgs args)
        {
            var players = await TournamentEntryService.GetSearchedPlayers(args.NameSurname);
            return players;
        }

        [HttpPost("AddTournamentPlayer")]
        public async Task<ActionResult<TournamentEntryDTO>> AddTournamentPlayer([FromBody]PlayerArgs args)
        {
            var entry = await TournamentEntryService.AddTournamentPlayer(args.TournamentId, args.PlayerId);
            var uri = "api/tournamentEntry";
            return Created(uri, entry);
        }

        [HttpDelete("DeleteTournamentPlayer")]
        public async Task<ActionResult> DeleteTournamentPlayer([FromQuery]DeletePlayerArgs args)
        {
            await TournamentEntryService.DeleteTournamentPlayer(args.TournamentEntryId);
            return Ok();
        }
    }
}
