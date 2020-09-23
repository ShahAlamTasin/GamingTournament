using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameTournament.Controllers
{
    public class CompetitionController : Controller
    {
        // GET: Competition
        public ActionResult Index()
        {
            return View();
        }
        
            public ActionResult SeeCompetitonDetails()
        {
            return View();
        }
        public ActionResult SeeCompetitionDetailsGamer()
        {
            return View();
        }
    }
}