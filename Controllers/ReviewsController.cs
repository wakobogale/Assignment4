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
    public class ReviewsController : Controller
    {
        private CPMSEntities db = new CPMSEntities();

        // GET: Reviews
        public ActionResult Index()
        {
            var reviews = db.Reviews.Include(r => r.Paper).Include(r => r.Reviewer);
            return View(reviews.ToList());
        }

        // GET: Reviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // GET: Reviews/Create
        public ActionResult Create()
        {
            ViewBag.PaperID = new SelectList(db.Papers, "PaperID", "FilenameOriginal");
            ViewBag.ReviewerID = new SelectList(db.Reviewers, "ReviewerID", "FirstName");
            return View();
        }

        // POST: Reviews/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReviewID,PaperID,ReviewerID,AppropriatenessOfTopic,TimelinessOfTopic,SupportiveEvidence,TechnicalQuality,ScopeOfCoverage,CitationOfPreviousWork,Originality,ContentComments,OrganizationOfPaper,ClarityOfMainMessage,Mechanics,WrittenDocumentComments,SuitabilityForPresentation,PotentialInterestInTopic,PotentialForOralPresentationComments,OverallRating,OverallRatingComments,ComfortLevelTopic,ComfortLevelAcceptability,Complete")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PaperID = new SelectList(db.Papers, "PaperID", "FilenameOriginal", review.PaperID);
            ViewBag.ReviewerID = new SelectList(db.Reviewers, "ReviewerID", "FirstName", review.ReviewerID);
            return View(review);
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            ViewBag.PaperID = new SelectList(db.Papers, "PaperID", "FilenameOriginal", review.PaperID);
            ViewBag.ReviewerID = new SelectList(db.Reviewers, "ReviewerID", "FirstName", review.ReviewerID);
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReviewID,PaperID,ReviewerID,AppropriatenessOfTopic,TimelinessOfTopic,SupportiveEvidence,TechnicalQuality,ScopeOfCoverage,CitationOfPreviousWork,Originality,ContentComments,OrganizationOfPaper,ClarityOfMainMessage,Mechanics,WrittenDocumentComments,SuitabilityForPresentation,PotentialInterestInTopic,PotentialForOralPresentationComments,OverallRating,OverallRatingComments,ComfortLevelTopic,ComfortLevelAcceptability,Complete")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Entry(review).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PaperID = new SelectList(db.Papers, "PaperID", "FilenameOriginal", review.PaperID);
            ViewBag.ReviewerID = new SelectList(db.Reviewers, "ReviewerID", "FirstName", review.ReviewerID);
            return View(review);
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Review review = db.Reviews.Find(id);
            db.Reviews.Remove(review);
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
