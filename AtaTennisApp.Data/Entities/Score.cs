using System;
using System.Collections.Generic;
using System.Text;

namespace AtaTennisApp.Data.Entities
{
    public class Score
    {
        public int Id { get; set; }
        public int SetNumber { get; set; }
        public int GamesWon { get; set; }
        public int MatchEntryId { get; set; }

        public virtual MatchEntry MatchEntry { get; set; }
    }
}
