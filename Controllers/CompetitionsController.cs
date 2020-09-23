using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GameTournament.Models;

namespace GameTournament.Controllers
{
    public class CompetitionsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Competitions
        public ActionResult Index()
        {
            var competition = db.Competition.Include(c => c.Organizer);
            return View(competition.ToList());
        }

        // GET: Competitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competition competition = db.Competition.Find(id);
            if (competition == null)
            {
                return HttpNotFound();
            }
            return View(competition);
        }

        // GET: Competitions/Create
        public ActionResult Create()
        {
            ViewBag.Organizerid = new SelectList(db.Organizer, "Organizerid", "organizername");
            return View();
        }

        // POST: Competitions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "")] Competition competition)
        {
            string fileDir = "~/Content/Upload/";
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                
                if (file != null && file.ContentLength > 0)
                {
                    
                    var ext = Path.GetExtension(file.FileName);
                    var fileName = competition.CompetitionName + ""+ext;
                    var path = Path.Combine(Server.MapPath("~/Content/Upload/"), fileName);
                    fileDir += fileName;
                    file.SaveAs(path);
                }
            }
            competition.competitionpicture = fileDir;
            competition.status = 1;
                db.Competition.Add(competition);
            db.SaveChanges();
            

            return RedirectToAction("Index","Competition",new { id = competition.Organizerid });

            
            ViewBag.Organizerid = new SelectList(db.Organizer, "Organizerid", "organizeremail", competition.Organizerid);
            return View("~/Views/Home/Competitonorganization.cshtml", competition);
        }

        // GET: Competitions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competition competition = db.Competition.Find(id);
            if (competition == null)
            {
                return HttpNotFound();
            }
            ViewBag.Organizerid = new SelectList(db.Organizer, "Organizerid", "organizername", competition.Organizerid);
            return View(competition);
        }

        // POST: Competitions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Competitionid,organizeremail,Organizerid,totalteams,Registrationfee,Registeredteams,competitionpicture,tournamentdeadline,Discordserverlink,googleformlink,status")] Competition competition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(competition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Organizerid = new SelectList(db.Organizer, "Organizerid", "organizername", competition.Organizerid);
            return View(competition);
        }

        // GET: Competitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competition competition = db.Competition.Find(id);
            if (competition == null)
            {
                return HttpNotFound();
            }
            return View(competition);
        }

        // POST: Competitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Competition competition = db.Competition.Find(id);
            db.Competition.Remove(competition);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
