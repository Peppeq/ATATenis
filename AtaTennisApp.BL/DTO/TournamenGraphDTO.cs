using AtaTennisApp.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtaTennisApp.BL.DTO
{
    public class TournamentGraphDTO
    {
        public TournamentDTO Tournament { get; set; }
        public List<PlayerDrawDTO> Players { get; set; } = new List<PlayerDrawDTO>();
        public List<MatchDTO> Matches { get; set; } = new List<MatchDTO>();
        public TournamentRound StartingRound { get; set; }
    }
}
