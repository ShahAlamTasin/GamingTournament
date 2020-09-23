using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameTournament.Models
{
    public class Gamer
    {
        [Key]
        public int GamerId { get; set; }
        [Required]
        public string GamerName { get; set; }

        [Required]
        [StringLength(100)]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        [Required]
        public string ContactNumber { get; set; }
        [Required]
        public string Passward { get; set; }
        [Required]
        public string InGameName { get; set; }

        [Required]
        public string Teamname { get; set; }

        [Required]
        public string Prefferedgame { get; set; }

        [Required]
        public int rating { get; set; }

        [Required]
        public int reviewmember { get; set; }




    }
}