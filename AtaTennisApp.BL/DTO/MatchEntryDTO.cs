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
        public int? PlayerId { get; set; } // spravit to nullable???
        // porozmyslat jak pridam ParentMatchId - Qualifier bez toho aby som vedel kto vyhra
        public int? ParentMatchId { get; set; }

        public virtual List<Score> Scores { get; set; } = new List<Score>();

        public virtual MatchDTO Match { get; set; }
        public virtual PlayerDTO Player { get; set; }
    }
}
