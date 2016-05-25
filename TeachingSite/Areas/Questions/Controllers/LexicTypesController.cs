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
    public class LexicTypesController : Controller
    {
        private QuestionsContext db = new QuestionsContext();

        // GET: Questions/LexicTypes
        public ActionResult Index()
        {
            return View(db.LexicTypes.ToList());
        }

        // GET: Questions/LexicTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LexicType lexicType = db.LexicTypes.Find(id);
            if (lexicType == null)
            {
                return HttpNotFound();
            }
            return View(lexicType);
        }

        // GET: Questions/LexicTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Questions/LexicTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Element")] LexicType lexicType)
        {
            if (ModelState.IsValid)
            {
                db.LexicTypes.Add(lexicType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lexicType);
        }

        // GET: Questions/LexicTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LexicType lexicType = db.LexicTypes.Find(id);
            if (lexicType == null)
            {
                return HttpNotFound();
            }
            return View(lexicType);
        }

        // POST: Questions/LexicTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Element")] LexicType lexicType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lexicType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lexicType);
        }

        // GET: Questions/LexicTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LexicType lexicType = db.LexicTypes.Find(id);
            if (lexicType == null)
            {
                return HttpNotFound();
            }
            return View(lexicType);
        }

        // POST: Questions/LexicTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LexicType lexicType = db.LexicTypes.Find(id);
            db.LexicTypes.Remove(lexicType);
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
