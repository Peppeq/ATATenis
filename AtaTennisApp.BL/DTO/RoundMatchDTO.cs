using System;
using System.Collections.Generic;
using System.Text;

namespace AtaTennisApp.BL.DTO
{
    public class RoundMatchDTO
    {
        public int Round { get; set; }
        public List<MatchDTO> Matches { get; set; }
    }
}
