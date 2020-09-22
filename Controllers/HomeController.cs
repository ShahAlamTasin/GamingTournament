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

        [HttpPost]
        
        public ActionResult OrganizerRegistration()
        {
            return View();
        }
        public ActionResult GamerProfileView()
        {
            return View();
        }
        public ActionResult Organizerprofileview()
        {
            return View();
        }
        
        
            public ActionResult Competitonorganization()
        {
            return View();
        }
    }
}