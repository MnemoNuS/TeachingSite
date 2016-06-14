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
    public class EslLevelsController : Controller
    {
        private QuestionsContext db = new QuestionsContext();

        // GET: Questions/EslLevels
        public ActionResult Index()
        {
            return View(db.EslLevels.ToList());
        }

        // GET: Questions/EslLevels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EslLevel eslLevel = db.EslLevels.Find(id);
            if (eslLevel == null)
            {
                return HttpNotFound();
            }
            return View(eslLevel);
        }

        // GET: Questions/EslLevels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Questions/EslLevels/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EslLevelName")] EslLevel eslLevel)
        {
            if (ModelState.IsValid)
            {
                db.EslLevels.Add(eslLevel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eslLevel);
        }

        // GET: Questions/EslLevels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EslLevel eslLevel = db.EslLevels.Find(id);
            if (eslLevel == null)
            {
                return HttpNotFound();
            }
            return View(eslLevel);
        }

        // POST: Questions/EslLevels/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EslLevelName")] EslLevel eslLevel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eslLevel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eslLevel);
        }

        // GET: Questions/EslLevels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EslLevel eslLevel = db.EslLevels.Find(id);
            if (eslLevel == null)
            {
                return HttpNotFound();
            }
            return View(eslLevel);
        }

        // POST: Questions/EslLevels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EslLevel eslLevel = db.EslLevels.Find(id);
            db.EslLevels.Remove(eslLevel);
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
