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
        private AtaTennisContext _dbContext;

        public MatchService MatchService { get; set; }
        public MatchController(AtaTennisContext dbContext)
        {
            _dbContext = dbContext;
            MatchService = new MatchService(_dbContext);
        }

        public class GetMatchesArgs
        {
            public int TournamentId { get; set; }
        }

        public class MatchesArgs
        {
            public int TournamentId { get; set; }
            public DrawSize DrawSize { get; set; }
            public List<MatchDTO> Matches { get; set; }
        }

        [HttpGet("GetMatches")]
        public async Task<List<MatchDTO>> GetMatches(GetMatchesArgs args)
        {
            var matches = await MatchService.GetMatchesByTournament(args.TournamentId);
            return matches;
        }

        [HttpPost("CreateOrUpdateMatches")]
        public async Task<ActionResult<List<MatchDTO>>> CreateOrUpdateMatches(MatchesArgs args)
        {
            var matches = default(List<MatchDTO>);
            if (args.Matches != null && args.Matches.Count > 0)
            {
                // matchService.UpdateMatches(MatchesDTO matches);
            }
            else
            {
                matches = await MatchService.CreateMatchesForTournament(args.DrawSize, args.TournamentId); ;
            }
            return matches;
        }
    }
}
