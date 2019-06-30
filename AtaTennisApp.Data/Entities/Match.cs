﻿using System;
using System.Collections.Generic;

namespace AtaTennisApp.Data.Entities
{
    public partial class Match
    {
        public Match()
        {
            DrawMatch = new HashSet<DrawMatch>();
            MatchPlayer = new HashSet<MatchPlayer>();
        }

        public int Id { get; set; }
        public int TournamentId { get; set; }
        public int Score { get; set; }
        public bool Retired { get; set; }

        public virtual Tournament Tournament { get; set; }
        public virtual ICollection<DrawMatch> DrawMatch { get; set; }
        public virtual ICollection<MatchPlayer> MatchPlayer { get; set; }
    }
}
