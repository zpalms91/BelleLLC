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
    public class LotionsController : Controller
    {
        private BelleLLCEntities1 db = new BelleLLCEntities1();

        // GET: Lotions
        public ActionResult Index()
        {
            var lotions = db.Lotions.Include(l => l.Label).Include(l => l.Product).Include(l => l.Scent).Include(l => l.Size);
            return View(lotions.ToList());
        }

        // GET: Lotions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lotion lotion = db.Lotions.Find(id);
            if (lotion == null)
            {
                return HttpNotFound();
            }
            return View(lotion);
        }

        // GET: Lotions/Create
        [Authorize(Roles = "Admin, Manager")]
        public ActionResult Create()
        {
            ViewBag.LabelId = new SelectList(db.Labels, "LabelId", "LabelDesc");
            ViewBag.TypeId = new SelectList(db.Products, "TypeId", "ProductName");
            ViewBag.ScentId = new SelectList(db.Scents, "ScentId", "ScentName");
            ViewBag.SizeId = new SelectList(db.Sizes, "SizeId", "SizeDesc");
            return View();
        }

        // POST: Lotions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LotionId,TypeId,LabelId,ScentId,SizeId,Price,Discount,AddCBD,AddMagOil,IsFeatured,Photo1,Photo2,Photo3,Photo4,Photo5,Notes")] Lotion lotion)
        {
            if (ModelState.IsValid)
            {
                db.Lotions.Add(lotion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LabelId = new SelectList(db.Labels, "LabelId", "LabelDesc", lotion.LabelId);
            ViewBag.TypeId = new SelectList(db.Products, "TypeId", "ProductName", lotion.TypeId);
            ViewBag.ScentId = new SelectList(db.Scents, "ScentId", "ScentName", lotion.ScentId);
            ViewBag.SizeId = new SelectList(db.Sizes, "SizeId", "SizeDesc", lotion.SizeId);
            return View(lotion);
        }

        // GET: Lotions/Edit/5
        [Authorize(Roles = "Admin, Manager")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lotion lotion = db.Lotions.Find(id);
            if (lotion == null)
            {
                return HttpNotFound();
            }
            ViewBag.LabelId = new SelectList(db.Labels, "LabelId", "LabelDesc", lotion.LabelId);
            ViewBag.TypeId = new SelectList(db.Products, "TypeId", "ProductName", lotion.TypeId);
            ViewBag.ScentId = new SelectList(db.Scents, "ScentId", "ScentName", lotion.ScentId);
            ViewBag.SizeId = new SelectList(db.Sizes, "SizeId", "SizeDesc", lotion.SizeId);
            return View(lotion);
        }

        // POST: Lotions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LotionId,TypeId,LabelId,ScentId,SizeId,Price,Discount,AddCBD,AddMagOil,IsFeatured,Photo1,Photo2,Photo3,Photo4,Photo5,Notes")] Lotion lotion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lotion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LabelId = new SelectList(db.Labels, "LabelId", "LabelDesc", lotion.LabelId);
            ViewBag.TypeId = new SelectList(db.Products, "TypeId", "ProductName", lotion.TypeId);
            ViewBag.ScentId = new SelectList(db.Scents, "ScentId", "ScentName", lotion.ScentId);
            ViewBag.SizeId = new SelectList(db.Sizes, "SizeId", "SizeDesc", lotion.SizeId);
            return View(lotion);
        }

        // GET: Lotions/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lotion lotion = db.Lotions.Find(id);
            if (lotion == null)
            {
                return HttpNotFound();
            }
            return View(lotion);
        }

        // POST: Lotions/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lotion lotion = db.Lotions.Find(id);
            db.Lotions.Remove(lotion);
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
