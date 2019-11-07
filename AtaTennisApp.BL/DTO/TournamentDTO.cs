using AtaTennisApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AtaTennisApp.BL.DTO
{
    public class TournamentDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime? EndTime { get; set; }
        [Required]
        public string Place { get; set; }
        //public DateTime? LoginDeadline { get; set; }
        //public int MaxPlayersCount { get; set; }
        //public string DrawLots { get; set; }
        public TournamentCategory Category { get; set; }
        public PlayingSystem PlayingSystem { get; set; }
        public BallsType? BallsType { get; set; }
        public TournamentType TournamentType { get; set; }
        public SurfaceType Surface { get; set; }
        public string Description { get; set; }
    }
}
