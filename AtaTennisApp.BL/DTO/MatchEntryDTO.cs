using AtaTennisApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtaTennisApp.BL.DTO
{
    public class MatchEntryDTO
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int? PlayerId { get; set; }
        public int? ParentMatchId { get; set; }
        public virtual List<ScoreDTO> Scores { get; set; } = new List<ScoreDTO>();

    }
}
