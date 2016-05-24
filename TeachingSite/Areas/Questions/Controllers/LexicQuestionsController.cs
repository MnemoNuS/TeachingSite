using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TeachingSite.Areas.Questions.Models;

namespace TeachingSite.Areas.Questions.Controllers
{
    public class LexicQuestionsController : Controller
    {
        private QuestionsContext db = new QuestionsContext();

        // GET: Questions/LexicQuestions
        public ActionResult Index()
        {
            var lexicQuestions = db.LexicQuestions.Include(l => l.LexicType);
            return View(lexicQuestions.ToList());
        }

        // GET: Questions/LexicQuestions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LexicQuestion lexicQuestion = db.LexicQuestions.Find(id);
            if (lexicQuestion == null)
            {
                return HttpNotFound();
            }
            return View(lexicQuestion);
        }

        // GET: Questions/LexicQuestions/Create
        public ActionResult Create()
        {
            ViewBag.LexicTypeId = new SelectList(db.LexicTypes, "Id", "Id");
            return View();
        }

        // POST: Questions/LexicQuestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Topic,LexicTypeId,Body,Answer,TypeId,Date")] LexicQuestion lexicQuestion)
        {
            if (ModelState.IsValid)
            {
                db.LexicQuestions.Add(lexicQuestion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LexicTypeId = new SelectList(db.LexicTypes, "Id", "Id", lexicQuestion.LexicTypeId);
            return View(lexicQuestion);
        }

        // GET: Questions/LexicQuestions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LexicQuestion lexicQuestion = db.LexicQuestions.Find(id);
            if (lexicQuestion == null)
            {
                return HttpNotFound();
            }
            ViewBag.LexicTypeId = new SelectList(db.LexicTypes, "Id", "Id", lexicQuestion.LexicTypeId);
            return View(lexicQuestion);
        }

        // POST: Questions/LexicQuestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Topic,LexicTypeId,Body,Answer,TypeId,Date")] LexicQuestion lexicQuestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lexicQuestion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LexicTypeId = new SelectList(db.LexicTypes, "Id", "Id", lexicQuestion.LexicTypeId);
            return View(lexicQuestion);
        }

        // GET: Questions/LexicQuestions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LexicQuestion lexicQuestion = db.LexicQuestions.Find(id);
            if (lexicQuestion == null)
            {
                return HttpNotFound();
            }
            return View(lexicQuestion);
        }

        // POST: Questions/LexicQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LexicQuestion lexicQuestion = db.LexicQuestions.Find(id);
            db.LexicQuestions.Remove(lexicQuestion);
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
