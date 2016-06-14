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
            return View(db.GrammaQuestions.ToList());
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
            ViewBag.GrammaCategories = db.GrammaCategories.Select(g=>g.GrammaCategoryName).ToList();
            ViewBag.EslLevels = db.EslLevels.Select(e=>e.EslLevelName).ToList();

            return View();
        }

        // POST: Questions/GrammaQuestions/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GrammaCategory,EslLevel,Body,Answer")] GrammaQuestion grammaQuestion)
        {
            if (ModelState.IsValid)
            {
                grammaQuestion.ModifiedAt = DateTime.Now;
                db.GrammaQuestions.Add(grammaQuestion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

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
            ViewBag.GrammaCategories = db.GrammaCategories.Select(g => g.GrammaCategoryName).ToList();
            ViewBag.EslLevels = db.EslLevels.Select(e => e.EslLevelName).ToList();
            return View(grammaQuestion);
        }

        // POST: Questions/GrammaQuestions/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GrammaCategory,EslLevel,Body,Answer")] GrammaQuestion grammaQuestion)
        {
            if (ModelState.IsValid)
            {
                grammaQuestion.ModifiedAt = DateTime.Now;
                db.Entry(grammaQuestion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
