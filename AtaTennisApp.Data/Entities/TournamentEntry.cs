using System;
using System.Collections.Generic;
using System.Text;

namespace AtaTennisApp.Data.Entities
{
    public class TournamentEntry
    {
        public int Id { get; set; }
        public int TournamentId { get; set; }
        public int PlayerId { get; set; }
        public virtual Tournament Tournament { get; set; }
        public virtual Player Player { get; set; }
    }
}
