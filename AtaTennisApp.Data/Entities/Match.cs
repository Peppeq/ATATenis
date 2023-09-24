using System;
using System.Collections.Generic;

namespace AtaTennisApp.Data.Entities
{
    public partial class Match
    {
        public Match()
        {
            // Hashset because it is much faster than list (searching and also inserting to collection)
            // but it is unordered and cannot be accesed by index
            MatchEntries = new HashSet<MatchEntry>();
        }

        public int Id { get; set; }
        public TournamentRound Round { get; set; }
        // Winner = PlayerId
        public int? Winner { get; set; }
        public int TournamentId { get; set; }
        //public bool Retired { get; set; }

        // ICollection for a list of object that needs to be iterated through
        // and modified (IEnumerable only iterated through) (List - iterated, modified, sort)
        public virtual ICollection<MatchEntry> MatchEntries { get; set; }
        public virtual Tournament Tournament { get; set; }  
    }
}
