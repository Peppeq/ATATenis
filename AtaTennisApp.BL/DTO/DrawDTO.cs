using AtaTennisApp.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtaTennisApp.BL.DTO
{
    public class DrawDTO
    {
        public TournamentRound InitialRound { get; set; }
        public int MatchesCount { get; set; }
        public List<RoundMatchDTO> RoundMatches { get; set; }
    }
}
