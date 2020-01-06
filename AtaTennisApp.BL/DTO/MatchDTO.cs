using System;
using System.Collections.Generic;
using System.Text;

namespace AtaTennisApp.BL.DTO
{
    public class MatchDTO
    {
        public int Id { get; set; }
        public int? Round { get; set; }
        public int? Winner { get; set; }
        public int TournamentId { get; set; }
        //public bool Retired { get; set; }

        public List<MatchEntryDTO> MatchEntries { get; set; } = new List<MatchEntryDTO>();
    }
}
