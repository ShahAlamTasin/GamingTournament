using GameTournament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameTournament.Controllers
{

    public class HomeController : Controller
    {

        private DatabaseContext db = new DatabaseContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult GamerRegistration()
        {
           
           
            return View();
        }

        
        public ActionResult OrganizerRegistration()
        {
            return View();
        }
        public ActionResult GamerProfileView()
        {
            return View();
        }
        public ActionResult Organizerprofileview(int id)
        {
            Organizer organizer = db.Organizer.Find(id);
            if (organizer == null)
            {
                return HttpNotFound();
            }
            return View(organizer);
        }

        public ActionResult GiveReview()
        {
            return View();
        }

        public ActionResult ProfileView(int id)
        {
            Gamer gamer = db.Gamers.Find(id);
            if (gamer == null)
            {
                return HttpNotFound();
            }
            return View(gamer);
        }
       
         public ActionResult Competitonorganization()
        {
            ViewBag.Organizerid = new SelectList(db.Organizer, "Organizerid", "organizeremail");
            return View();
        }
    }
}