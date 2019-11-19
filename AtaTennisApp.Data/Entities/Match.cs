using System;
using System.Collections.Generic;

namespace AtaTennisApp.Data.Entities
{
    public partial class Match
    {
        public Match()
        {
            MatchEntries = new HashSet<MatchEntry>();
        }

        public int Id { get; set; }
        public int Round { get; set; }
        // Winner = PlayerId
        public int Winner { get; set; }
        //public bool Retired { get; set; }

        public virtual ICollection<MatchEntry> MatchEntries { get; set; }
    }
}
