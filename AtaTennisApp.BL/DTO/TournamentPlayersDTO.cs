using System;
using System.Collections.Generic;
using System.Text;

namespace AtaTennisApp.BL.DTO
{
    public class TournamentPlayersDTO
    {
        public TournamentDTO Tournament { get; set; }
        public List<PlayerDrawDTO> Players { get; set; }
    }
}
