using AtaTennisApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AtaTennisApp.BL.DTO
{
    public class TournamentFilterDTO
    {
        public int? Id { get; set; }
        public int? Year { get; set; }
        public TournamentType? Type { get; set; }
    }
}
