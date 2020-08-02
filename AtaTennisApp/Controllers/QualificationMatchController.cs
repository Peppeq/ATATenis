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
    public class QualificationMatchController : ApiControllerBase
    {
        public MatchService MatchService { get; set; }
        public QualificationMatchController(AtaTennisContext dbContext)
        {
            MatchService = new MatchService(dbContext);
        }

        public class QualificationMatch
        {
            public int ChildMatchId { get; set; }
        }


        [HttpPost("CreateQualificationMatch")]
        public async Task<ActionResult<MatchDTO>> CreateQualificationMatch([FromBody]QualificationMatch args)
        {
            var draw = await MatchService.CreateQualificationMatch(args.ChildMatchId);
            
            return draw;
        }


        //[HttpDelete("DeleteQualificationMatch")]
        //public async Task<ActionResult> DeleteQualificationMatch([FromQuery]int matchId)
        //{
        //    await MatchService.DeleteQualificationMatch(matchId);
        //    return Ok();
        //}
    }
}
