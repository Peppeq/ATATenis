using System;
using System.Collections.Generic;
using System.Text;

namespace AtaTennisApp.BL.DTO
{
    public class ScoreDTO
    {
        public int Id { get; set; }
        public int SetNumber { get; set; }
        public int GamesWon { get; set; }
        public int MatchEntryId { get; set; }
    }
}
