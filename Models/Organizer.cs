using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameTournament.Models
{
    public class Organizer
    {
        [Key]
        public int Organizerid { get; set; }
        [Required]
        public string organizername { get; set; }
        [Required]
        public String Organizeremail { get; set; }
        [Required]
        public string organizercontactnum{ get; set; }
        [Required]
        public string Passward { get; set; }
     
        [Required]
        public int rating { get; set; }

        [Required]
        public int reviewmember { get; set; }

    }
}