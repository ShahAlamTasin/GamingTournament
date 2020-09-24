using GameTournament.Models;
using GameTournament.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

        public ActionResult SendEmail()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var client = new SmtpClient("smtp.mailtrap.io", 2525)
                    {
                        Credentials = new NetworkCredential("52989bbb90ab6d", "90b65713e2b630"),
                        EnableSsl = true
                    };
                    client.Send("from@example.com", "to@example.com", "Hello world", "testbody");
                    Console.WriteLine("Sent");
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }
            return View();
        }


        public ActionResult GamerCompitionList()
        {
            HttpCookie myCookie = AuthUser.getUserType();

            if (myCookie.Value.Contains("gamer"))
            {
                Gamer gm = AuthUser.getGamerUser();
                string gameName = gm.Prefferedgame;

                IEnumerable<Competition> competitions = db.Competition.Where(u => u.GameName.Contains(gameName));

                return View(competitions);
            }
            else if (myCookie.Value.Contains("organizer"))
            {
                return RedirectToAction("Error");
            }
            return Content("Somthing Goes Wrong");
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
        [CustomAuthrizationRedirect("DashBoard", "Home")]
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            AuthUser.signOutAdminUser();
            return RedirectToAction("Login");
        }
        public ActionResult DashBoard()
        {

            System.Diagnostics.Debug.WriteLine(AuthUser.isAdminLogIn());
            if (AuthUser.isAdminLogIn())
            {
                HttpCookie myCookie = AuthUser.getUserType();

                if (myCookie.Value.Contains("gamer"))
                {
                    Gamer gm = AuthUser.getGamerUser();
                    return RedirectToAction("ProfileView", "Home", new { id = gm.GamerId });
                }
                if (myCookie.Value.Contains("organizer"))
                {
                    Organizer or = AuthUser.getOrganizerUser();
                    return RedirectToAction("Organizerprofileview", "Home", new { id = or.Organizerid });
                }
            }
            else
            {
                return RedirectToAction("Logout");
            }
            return null;
        }

        [HttpPost]
        [CustomAuthrizationRedirect("DashBoard", "Home")]
        public ActionResult LoginFormSubmit()
        {
            var email = Request["email"];
            var password = Request["password"];
            var UserType = Request["UserType"];
            if (UserType.Contains("gamer"))
            {
                bool isHave = db.Gamers.Any(u => u.Email == email
                         && u.Passward == password);
                if (!isHave)
                    return Content("No user Found");
                else
                {
                    Gamer gamer = db.Gamers.Where(u => u.Email == email
                         && u.Passward == password).SingleOrDefault();
                    AuthUser.setGamerInCookie(gamer.GamerId + "");
                    return RedirectToAction("ProfileView", "Home", new { id = gamer.GamerId });
                }
            }
            else if(UserType.Contains("organizer"))
            {
                bool isHave = db.Organizer.Any(u => u.Organizeremail == email
                        && u.Passward == password);
                if (!isHave)
                    return Content("No user Found");
                else
                {
                    Organizer organizer = db.Organizer.Where(u => u.Organizeremail == email
                         && u.Passward == password).SingleOrDefault();

                    AuthUser.setOrganizerInCookie(organizer.Organizerid + "");
                    return RedirectToAction("Organizerprofileview", "Home", new { id = organizer.Organizerid });
                }
            }
            return null;
            //return RedirectToAction("ProfileView", "Home", new { id = gamer.GamerId });
            /*return RedirectToAction("Organizerprofileview", "Home", new { id = organizer.Organizerid });
            return RedirectToAction("","");*/
        }
        [CustomAuthrizationRedirect("DashBoard", "Home")]
        public ActionResult GamerRegistration()
        {
               return View();
        }

        [CustomAuthrizationRedirect("DashBoard", "Home")]
        public ActionResult OrganizerRegistration()
        {
            return View();
        }
        [CustomAuthrization]
        public ActionResult GamerProfileView()
        {
            return View();
        }
        [CustomAuthrization]
        public ActionResult Organizerprofileview(int id)
        {
            Organizer organizer = db.Organizer.Find(id);
            if (organizer == null)
            {
                return HttpNotFound();
            }
            return View(organizer);
        }


        [CustomAuthrization]
        public ActionResult ProfileView(int id)
        {
            Gamer gamer = db.Gamers.Find(id);
            if (gamer == null)
            {
                return HttpNotFound();
            }
            return View(gamer);
        }


        
        public ActionResult GiveReview()
        {
            ViewBag.Organizerid = new SelectList(db.Organizer, "Organizerid", "organizeremail");
            return View();
        }

        [HttpPost]
        public ActionResult GiveReviewForm()
        {
            string type = Request["type"];
            string email = Request["email"];
            string rating = Request["rating"];
            if(email == null || email== "")
            {
                return Content("Please Give Email");
            }

            HttpCookie myCookie = AuthUser.getUserType();

            if (myCookie.Value.Contains("gamer"))
            {
                Gamer gm = AuthUser.getGamerUser();
                if ( type.Contains("gamer"))
                {
                    return Content("You Can not review Gammer");
                }
                else
                {
                        Organizer gn = db.Organizer.Where(u => u.Organizeremail == email).SingleOrDefault();
                        if (gn == null)
                            return Content("Please Give Correct User email");
                        else
                        {
                            gn.rating += Convert.ToInt32(rating);
                            gn.reviewmember += 1;
                            db.SaveChanges();
                        }
                  
                }
                return RedirectToAction("ProfileView", "Home", new { id = gm.GamerId });

            }
            if (myCookie.Value.Contains("organizer"))
            {
                Organizer or = AuthUser.getOrganizerUser();
                
                if (type.Contains("organizer"))
                {
                    return Content("You Can not review Organizer");
                }
                else
                {
                    Gamer gn = db.Gamers.Where(u => u.Email == email).SingleOrDefault();
                    if (gn == null)
                        return Content("Please Give Correct User email");
                    else
                    {
                        gn.rating += Convert.ToInt32(rating);
                        gn.reviewmember += 1;
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("Organizerprofileview", "Home", new { id = or.Organizerid });

            }

            return Content("Thank you giving rating email " + email);
        }



        public ActionResult Competitonorganization()
        {
            ViewBag.Organizerid = new SelectList(db.Organizer, "Organizerid", "organizeremail");
            return View();
        }

        public ActionResult Error()

        {
            return Content("Error Page");
            
        }
    }
}