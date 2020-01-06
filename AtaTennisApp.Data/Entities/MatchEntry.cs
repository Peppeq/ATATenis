using System;
using System.Collections.Generic;

namespace AtaTennisApp.Data.Entities
{
    public partial class MatchEntry
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int? PlayerId { get; set; }
        public int? ParentMatchId { get; set; }

        public virtual List<Score> Scores { get; set; }

        public virtual Match Match { get; set; }
        public virtual Player Player { get; set; }
    }
}
