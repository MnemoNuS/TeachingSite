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
    public class GrammaCategoriesController : Controller
    {
        private QuestionsContext db = new QuestionsContext();

        // GET: Questions/GrammaCategories
        public ActionResult Index()
        {
            return View(db.GrammaCategories.ToList());
        }

        // GET: Questions/GrammaCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrammaCategory grammaCategory = db.GrammaCategories.Find(id);
            if (grammaCategory == null)
            {
                return HttpNotFound();
            }
            return View(grammaCategory);
        }

        // GET: Questions/GrammaCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Questions/GrammaCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id")] GrammaCategory grammaCategory)
        {
            if (ModelState.IsValid)
            {
                db.GrammaCategories.Add(grammaCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grammaCategory);
        }

        // GET: Questions/GrammaCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrammaCategory grammaCategory = db.GrammaCategories.Find(id);
            if (grammaCategory == null)
            {
                return HttpNotFound();
            }
            return View(grammaCategory);
        }

        // POST: Questions/GrammaCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id")] GrammaCategory grammaCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grammaCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grammaCategory);
        }

        // GET: Questions/GrammaCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrammaCategory grammaCategory = db.GrammaCategories.Find(id);
            if (grammaCategory == null)
            {
                return HttpNotFound();
            }
            return View(grammaCategory);
        }

        // POST: Questions/GrammaCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GrammaCategory grammaCategory = db.GrammaCategories.Find(id);
            db.GrammaCategories.Remove(grammaCategory);
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
