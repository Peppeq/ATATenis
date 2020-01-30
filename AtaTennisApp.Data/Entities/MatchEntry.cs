using System;
using System.Collections.Generic;

namespace AtaTennisApp.Data.Entities
{
    public partial class MatchEntry
    {
        public MatchEntry()
        {
            // Hashset because it is much faster than list (searching and also inserting to collection) but it is unordered and cannot be accesed by index
            Scores = new HashSet<Score>();
        }

        public int Id { get; set; }
        public int MatchId { get; set; }
        public int? PlayerId { get; set; }
        public int? ParentMatchId { get; set; }

        public virtual ICollection<Score> Scores { get; set; }

        public virtual Match Match { get; set; }
        public virtual Player Player { get; set; }
    }
}
