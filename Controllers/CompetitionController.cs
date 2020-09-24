using GameTournament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameTournament.Controllers
{
    public class CompetitionController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        // GET: Competition
        public ActionResult Index(int id)
        {
            IEnumerable<Competition> data = db.Competition.Where(u => u.Organizer.Organizerid == id);
            return View(data.ToList());
        }
        
         public ActionResult SeeCompetitonDetails(int id)
        {
            Competition data = db.Competition.Find(id);
            if (data == null)
            {
                return HttpNotFound(); 
            }
            System.Diagnostics.Debug.WriteLine(data.CompetitionName);
            return View(data);
        }
        public ActionResult SeeCompetitionDetailsGamer(int id)
        {
            Competition data = db.Competition.Find(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            System.Diagnostics.Debug.WriteLine(data.CompetitionName);
            return View(data);
        }
    }
}