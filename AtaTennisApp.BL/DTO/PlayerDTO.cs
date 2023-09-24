using AtaTennisApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AtaTennisApp.BL.DTO
{
    public class PlayerDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
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
        public int? Points { get; set; }
    }
}
