using System;
using System.Collections.Generic;

namespace AtaTennisApp.Data.Entities
{
    public partial class Player
    {
        public Player()
        {
            MatchAwayPlayer = new HashSet<Match>();
            MatchHomePlayer = new HashSet<Match>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public virtual ICollection<Match> MatchAwayPlayer { get; set; }
        public virtual ICollection<Match> MatchHomePlayer { get; set; }
    }
}
