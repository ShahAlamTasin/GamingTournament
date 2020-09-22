using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GameTournament.Models
{
    public class  DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DefaultConnection")
        {
           
        }
        public System.Data.Entity.DbSet<GameTournament.Models.Gamer> Gamers { get; set; }
        public System.Data.Entity.DbSet<GameTournament.Models.Organizer> Organizer { get; set; }

        public System.Data.Entity.DbSet<GameTournament.Models.Competition> Competition { get; set; }
    }
}