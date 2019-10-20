using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AtaTennisApp.BL.DTO
{
    public class UserDTO
    {
        [Required]
        [StringLength(255)]
        public string Username { get; set; }
        [Required]
        [StringLength(32)]
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
