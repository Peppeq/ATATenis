using System;
using System.Collections.Generic;
using System.Text;

namespace AtaTennisApp.BL.DTO
{
    public class SearchedTournamentDTO
    {
        public int TournamentId { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
    }
}
