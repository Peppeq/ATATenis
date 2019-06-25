using System;
using System.Collections.Generic;

namespace AtaTennisApp.Data.Entities
{
    public partial class Match
    {
        public int Id { get; set; }
        public int HomePlayerId { get; set; }
        public int AwayPlayerId { get; set; }
        public int TournamentId { get; set; }
        public string Result { get; set; }

        public virtual Player AwayPlayer { get; set; }
        public virtual Player HomePlayer { get; set; }
        public virtual Tournament Tournament { get; set; }
    }
}
