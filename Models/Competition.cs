using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameTournament.Models
{
    public class Competition
    {
        [Key]
        public int Competitionid { get; set; }
        [Required]
        public string organizeremail { get; set; }

        public virtual Organizer Organizer { get; set; }
        public int ? Organizerid { get; set; }
        [Required]
        public string totalteams { get; set; }
        [Required]
        public int Registrationfee{ get; set; }
      
        [Required]
        public int Registeredteams{ get; set; }

        [Required]
        public string competitionpicture{ get; set; }

        [Required]
        public DateTime tournamentdeadline{ get; set; }

        [Required]
        public string Discordserverlink { get; set; }


        [Required]
        public string googleformlink { get; set; }


        [Required]
        public int status { get; set; }
    }
}