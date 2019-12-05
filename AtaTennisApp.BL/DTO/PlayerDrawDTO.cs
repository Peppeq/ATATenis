using System;
using System.Collections.Generic;
using System.Text;

namespace AtaTennisApp.BL.DTO
{
    public class PlayerDrawDTO
    {
        public int TournamentEntryId { get; set; }
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
