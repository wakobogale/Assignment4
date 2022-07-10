using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class PapersController : Controller
    {
        private CPMSEntities db = new CPMSEntities();

        // GET: Papers
        public ActionResult Index()
        {
            var papers = db.Papers.Include(p => p.Author);
            return View(papers.ToList());
        }

        // GET: Papers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paper paper = db.Papers.Find(id);
            if (paper == null)
            {
                return HttpNotFound();
            }
            return View(paper);
        }

        // GET: Papers/Create
        public ActionResult Create()
        {
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "FirstName");
            return View();
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaperID,AuthorID,Active,FilenameOriginal,Filename,Title,Certification,NotesToReviewers,AnalysisOfAlgorithms,Applications,Architecture,ArtificialIntelligence,ComputerEngineering,Curriculum,DataStructures,Databases,DistanceLearning,DistributedSystems,EthicalSocietalIssues,FirstYearComputing,GenderIssues,GrantWriting,GraphicsImageProcessing,HumanComputerInteraction,LaboratoryEnvironments,Literacy,MathematicsInComputing,Multimedia,NetworkingDataCommunications,NonMajorCourses,ObjectOrientedIssues,OperatingSystems,ParallelsProcessing,Pedagogy,ProgrammingLanguages,Research,Security,SoftwareEngineering,SystemsAnalysisAndDesign,UsingTechnologyInTheClassroom,WebAndInternetProgramming,Other,OtherDescription")] Paper paper)
        {
            if (ModelState.IsValid)
            {
                db.Papers.Add(paper);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "FirstName", paper.AuthorID);
            return View(paper);
        }

        // GET: Papers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paper paper = db.Papers.Find(id);
            if (paper == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "FirstName", paper.AuthorID);
            return View(paper);
        }

        // POST: Papers/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaperID,AuthorID,Active,FilenameOriginal,Filename,Title,Certification,NotesToReviewers,AnalysisOfAlgorithms,Applications,Architecture,ArtificialIntelligence,ComputerEngineering,Curriculum,DataStructures,Databases,DistanceLearning,DistributedSystems,EthicalSocietalIssues,FirstYearComputing,GenderIssues,GrantWriting,GraphicsImageProcessing,HumanComputerInteraction,LaboratoryEnvironments,Literacy,MathematicsInComputing,Multimedia,NetworkingDataCommunications,NonMajorCourses,ObjectOrientedIssues,OperatingSystems,ParallelsProcessing,Pedagogy,ProgrammingLanguages,Research,Security,SoftwareEngineering,SystemsAnalysisAndDesign,UsingTechnologyInTheClassroom,WebAndInternetProgramming,Other,OtherDescription")] Paper paper)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paper).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "FirstName", paper.AuthorID);
            return View(paper);
        }

        // GET: Papers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paper paper = db.Papers.Find(id);
            if (paper == null)
            {
                return HttpNotFound();
            }
            return View(paper);
        }

        // POST: Papers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paper paper = db.Papers.Find(id);
            db.Papers.Remove(paper);
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
