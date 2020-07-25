using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BelleEssense.DATA;

namespace BelleEssense.UI.Controllers
{
    public class ScentsController : Controller
    {
        private BelleLLCEntities1 db = new BelleLLCEntities1();

        // GET: Scents
        public ActionResult Index()
        {
            return View(db.Scents.ToList());
        }

        // GET: Scents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scent scent = db.Scents.Find(id);
            if (scent == null)
            {
                return HttpNotFound();
            }
            return View(scent);
        }

        // GET: Scents/Create
        [Authorize(Roles = "Admin, Manager")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Scents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ScentId,ScentName,ScentDesc")] Scent scent)
        {
            if (ModelState.IsValid)
            {
                db.Scents.Add(scent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(scent);
        }

        // GET: Scents/Edit/5
        [Authorize(Roles = "Admin, Manager")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scent scent = db.Scents.Find(id);
            if (scent == null)
            {
                return HttpNotFound();
            }
            return View(scent);
        }

        // POST: Scents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ScentId,ScentName,ScentDesc")] Scent scent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scent);
        }

        // GET: Scents/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scent scent = db.Scents.Find(id);
            if (scent == null)
            {
                return HttpNotFound();
            }
            return View(scent);
        }

        // POST: Scents/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Scent scent = db.Scents.Find(id);
            db.Scents.Remove(scent);
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
