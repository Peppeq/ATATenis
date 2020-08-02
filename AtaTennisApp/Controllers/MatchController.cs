using AtaTennisApp.BL;
using AtaTennisApp.BL.DTO;
using AtaTennisApp.Controllers.Base;
using AtaTennisApp.Data;
using AtaTennisApp.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtaTennisApp.Controllers
{
    [Route("api/[controller]")]
    public class MatchController : ApiControllerBase
    {
        public MatchService MatchService { get; set; }
        public MatchController(AtaTennisContext dbContext)
        {
            MatchService = new MatchService(dbContext);
        }

        public class MatchesArgs
        {
            public int TournamentId { get; set; }
        }

        public class CreateOrUpdateMatchesArgs
        {
            public int TournamentId { get; set; }
            public DrawSize DrawSize { get; set; }
            public List<MatchDTO> Matches { get; set; }
        }
        
        [HttpGet("GetMatches")]
        public async Task<ActionResult<List<MatchDTO>>> GetMatches([FromQuery]MatchesArgs args)
        {
            var matches = await MatchService.GetMatchesByTournament(args.TournamentId);
            return matches;
        }

        [HttpPost("CreateOrUpdateMatches")]
        public async Task<ActionResult<DrawDTO>> CreateOrUpdateMatches([FromBody]CreateOrUpdateMatchesArgs args)
        {
            var draw = await MatchService.CreateOrUpdateMatchesForTournament(args.DrawSize, args.TournamentId, args.Matches);
            return draw;
        }
               
        [HttpDelete("DeleteTournamentDrawGraph")]
        public async Task<ActionResult> DeleteTournamentDrawGraph([FromQuery]MatchesArgs args)
        {
            await MatchService.DeleteMatchesGraph(args.TournamentId);
            return Ok();
        }
    }
}
