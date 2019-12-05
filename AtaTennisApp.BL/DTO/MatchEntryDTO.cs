using AtaTennisApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtaTennisApp.BL.DTO
{
    public class MatchEntryDTO
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int PlayerId { get; set; }
        public int ParentMatchId { get; set; }

        public virtual List<Score> Scores { get; set; }

        public virtual MatchDTO Match { get; set; }
        public virtual PlayerDTO Player { get; set; }
    }
}
