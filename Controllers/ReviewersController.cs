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
    public class ReviewersController : Controller
    {
        private CPMSEntities db = new CPMSEntities();

        // GET: Reviewers
        public ActionResult Index()
        {
            return View(db.Reviewers.ToList());
        }

        // GET: Reviewers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reviewer reviewer = db.Reviewers.Find(id);
            if (reviewer == null)
            {
                return HttpNotFound();
            }
            return View(reviewer);
        }

        // GET: Reviewers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reviewers/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReviewerID,Active,FirstName,MiddleInitial,LastName,Affiliation,Department,Address,City,State,ZipCode,PhoneNumber,EmailAddress,Password,AnalysisOfAlgorithms,Applications,Architecture,ArtificialIntelligence,ComputerEngineering,Curriculum,DataStructures,Databases,DistancedLearning,DistributedSystems,EthicalSocietalIssues,FirstYearComputing,GenderIssues,GrantWriting,GraphicsImageProcessing,HumanComputerInteraction,LaboratoryEnvironments,Literacy,MathematicsInComputing,Multimedia,NetworkingDataCommunications,NonMajorCourses,ObjectOrientedIssues,OperatingSystems,ParallelProcessing,Pedagogy,ProgrammingLanguages,Research,Security,SoftwareEngineering,SystemsAnalysisAndDesign,UsingTechnologyInTheClassroom,WebAndInternetProgramming,Other,OtherDescription,ReviewsAcknowledged")] Reviewer reviewer)
        {
            if (ModelState.IsValid)
            {
                db.Reviewers.Add(reviewer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reviewer);
        }

        // GET: Reviewers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reviewer reviewer = db.Reviewers.Find(id);
            if (reviewer == null)
            {
                return HttpNotFound();
            }
            return View(reviewer);
        }

        // POST: Reviewers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReviewerID,Active,FirstName,MiddleInitial,LastName,Affiliation,Department,Address,City,State,ZipCode,PhoneNumber,EmailAddress,Password,AnalysisOfAlgorithms,Applications,Architecture,ArtificialIntelligence,ComputerEngineering,Curriculum,DataStructures,Databases,DistancedLearning,DistributedSystems,EthicalSocietalIssues,FirstYearComputing,GenderIssues,GrantWriting,GraphicsImageProcessing,HumanComputerInteraction,LaboratoryEnvironments,Literacy,MathematicsInComputing,Multimedia,NetworkingDataCommunications,NonMajorCourses,ObjectOrientedIssues,OperatingSystems,ParallelProcessing,Pedagogy,ProgrammingLanguages,Research,Security,SoftwareEngineering,SystemsAnalysisAndDesign,UsingTechnologyInTheClassroom,WebAndInternetProgramming,Other,OtherDescription,ReviewsAcknowledged")] Reviewer reviewer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reviewer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reviewer);
        }

        // GET: Reviewers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reviewer reviewer = db.Reviewers.Find(id);
            if (reviewer == null)
            {
                return HttpNotFound();
            }
            return View(reviewer);
        }

        // POST: Reviewers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reviewer reviewer = db.Reviewers.Find(id);
            db.Reviewers.Remove(reviewer);
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
