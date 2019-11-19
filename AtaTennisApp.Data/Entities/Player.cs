using System;
using System.Collections.Generic;

namespace AtaTennisApp.Data.Entities
{
    public partial class Player
    {
        public Player()
        {
            TournamentEntries = new HashSet<TournamentEntry>();
            MatchEntries = new HashSet<MatchEntry>();
            Matches = new HashSet<Match>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
        public string Residence { get; set; }
        public Forehand? Forehand { get; set; }
        public Backhand? Backhand { get; set; }
        public string Racquet { get; set; }
        public SurfaceType? Surface { get; set; }
        public string FavouritePlayer { get; set; }
        public bool Member { get; set; } = false;
        public int Points { get; set; } = 0;

        public virtual ICollection<TournamentEntry> TournamentEntries { get; set; }
        public virtual ICollection<MatchEntry> MatchEntries { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
    }
}
