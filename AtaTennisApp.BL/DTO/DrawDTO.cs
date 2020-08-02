using AtaTennisApp.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtaTennisApp.BL.DTO
{
    public class DrawDTO
    {
        int TournamentId { get; set; }
        DrawSize DrawSize { get; set; }
        public List<RoundMatchDTO> RoundMatches { get; set; }

    }
}
