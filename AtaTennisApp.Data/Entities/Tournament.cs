using System;
using System.Collections.Generic;

namespace AtaTennisApp.Data.Entities
{
    public partial class Tournament
    {
        public Tournament()
        {
            Draw = new Draw();
            Match = new HashSet<Match>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Place { get; set; }
        public TournamentCategory Category { get; set; }
        public PlayingSystem PlayingSystem { get; set; }
        public BallsType? BallsType { get; set; }
        public string Description { get; set; }
        public TournamentType TournamentType { get; set; }

        public virtual Draw Draw { get; set; }
        public virtual ICollection<Match> Match { get; set; }
    }
}
