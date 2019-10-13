﻿using System;
using System.Collections.Generic;

namespace AtaTennisApp.Data.Entities
{
    public partial class Player
    {
        public Player()
        {
            MatchPlayer = new HashSet<MatchPlayer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Age { get; set; }
        public int? Height { get; set; }
        public string Residence { get; set; }
        public Forehand? Forehand { get; set; }
        public Backhand? Backhand { get; set; }
        public string Racquet { get; set; }
        public SurfaceType? Surface { get; set; }
        public string FavouritePlayer { get; set; }
        public int? TitlesCount { get; set; }
        public int? FinalistCount { get; set; }
        public int? TournamentCount { get; set; }
        public bool? Member { get; set; }
        public int Points { get; set; }

        public virtual ICollection<MatchPlayer> MatchPlayer { get; set; }
    }
}
