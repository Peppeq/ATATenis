using AtaTennisApp.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtaTennisApp.BL.DTO
{
    public class TournamentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Place { get; set; }
        public TournamentCategory Category { get; set; }
        public PlayingSystem PlayingSystem { get; set; }
        public BallsType? BallsType { get; set; }
        public string Description { get; set; }
        public TournamentType TournamentType { get; set; }
        public SurfaceType Surface { get; set; }
    }
}
