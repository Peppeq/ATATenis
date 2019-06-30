using System;
using System.Collections.Generic;

namespace AtaTennisApp.Data.Entities
{
    public partial class Draw
    {
        public Draw()
        {
            DrawMatch = new HashSet<DrawMatch>();
        }

        public int Id { get; set; }
        public int Type { get; set; }
        public int CountOfPlayers { get; set; }
        public int TournamentId { get; set; }
        public int Round { get; set; }

        public virtual Tournament Tournament { get; set; }
        public virtual ICollection<DrawMatch> DrawMatch { get; set; }
    }
}
