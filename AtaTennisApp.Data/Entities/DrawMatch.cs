using System;
using System.Collections.Generic;

namespace AtaTennisApp.Data.Entities
{
    public partial class DrawMatch
    {
        public int DrawId { get; set; }
        public int MatchId { get; set; }

        public virtual Draw Draw { get; set; }
        public virtual Match Match { get; set; }
    }
}
