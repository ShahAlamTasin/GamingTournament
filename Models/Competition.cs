using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameTournament.Models
{
    public class Competition
    {
        [Key]
        public int Competitionid { get; set; }

        public virtual Organizer Organizer { get; set; }
        public int ? Organizerid { get; set; }

        [Required]
        public string CompetitionName { get; set; }

        [Required]
        public string totalteams { get; set; }
        [Required]
        public int Registrationfee{ get; set; }

        [Required]
        public string GameName { get; set; }

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