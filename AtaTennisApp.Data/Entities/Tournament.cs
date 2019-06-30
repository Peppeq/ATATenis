using System;
using System.Collections.Generic;

namespace AtaTennisApp.Data.Entities
{
    public partial class Tournament
    {
        public Tournament()
        {
            Draw = new HashSet<Draw>();
            Match = new HashSet<Match>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Place { get; set; }
        public int Category { get; set; }
        public int PlayingSystem { get; set; }
        public int? BallsType { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Draw> Draw { get; set; }
        public virtual ICollection<Match> Match { get; set; }
    }
}
