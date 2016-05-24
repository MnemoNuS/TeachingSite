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
    public class GrammaQuestionsController : Controller
    {
        private QuestionsContext db = new QuestionsContext();

        // GET: Questions/GrammaQuestions
        public ActionResult Index()
        {
            var grammaQuestions = db.GrammaQuestions.Include(g => g.EslLevel);
            return View(grammaQuestions.ToList());
        }

        // GET: Questions/GrammaQuestions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrammaQuestion grammaQuestion = db.GrammaQuestions.Find(id);
            if (grammaQuestion == null)
            {
                return HttpNotFound();
            }
            return View(grammaQuestion);
        }

        // GET: Questions/GrammaQuestions/Create
        public ActionResult Create()
        {
            ViewBag.EslLevelId = new SelectList(db.EslLevels, "Id", "Id");
            return View();
        }

        // POST: Questions/GrammaQuestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EslLevelId,GramaCategoryId,Body,Answer,TypeId,Date")] GrammaQuestion grammaQuestion)
        {
            if (ModelState.IsValid)
            {
                db.GrammaQuestions.Add(grammaQuestion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EslLevelId = new SelectList(db.EslLevels, "Id", "Id", grammaQuestion.EslLevelId);
            return View(grammaQuestion);
        }

        // GET: Questions/GrammaQuestions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrammaQuestion grammaQuestion = db.GrammaQuestions.Find(id);
            if (grammaQuestion == null)
            {
                return HttpNotFound();
            }
            ViewBag.EslLevelId = new SelectList(db.EslLevels, "Id", "Id", grammaQuestion.EslLevelId);
            return View(grammaQuestion);
        }

        // POST: Questions/GrammaQuestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EslLevelId,GramaCategoryId,Body,Answer,TypeId,Date")] GrammaQuestion grammaQuestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grammaQuestion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EslLevelId = new SelectList(db.EslLevels, "Id", "Id", grammaQuestion.EslLevelId);
            return View(grammaQuestion);
        }

        // GET: Questions/GrammaQuestions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrammaQuestion grammaQuestion = db.GrammaQuestions.Find(id);
            if (grammaQuestion == null)
            {
                return HttpNotFound();
            }
            return View(grammaQuestion);
        }

        // POST: Questions/GrammaQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GrammaQuestion grammaQuestion = db.GrammaQuestions.Find(id);
            db.GrammaQuestions.Remove(grammaQuestion);
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
