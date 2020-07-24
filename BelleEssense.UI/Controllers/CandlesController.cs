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
    public class CandlesController : Controller
    {
        private BelleLLCEntities1 db = new BelleLLCEntities1();

        // GET: Candles
        public ActionResult Index()
        {
            var candles = db.Candles.Include(c => c.Label).Include(c => c.Product).Include(c => c.Scent).Include(c => c.Size);
            return View(candles.ToList());
        }

        // GET: Candles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candle candle = db.Candles.Find(id);
            if (candle == null)
            {
                return HttpNotFound();
            }
            return View(candle);
        }

        // GET: Candles/Create
        public ActionResult Create()
        {
            ViewBag.LabelId = new SelectList(db.Labels, "LabelId", "LabelDesc");
            ViewBag.TypeId = new SelectList(db.Products, "TypeId", "ProductName");
            ViewBag.ScentId = new SelectList(db.Scents, "ScentId", "ScentName");
            ViewBag.SizeId = new SelectList(db.Sizes, "SizeId", "SizeDesc");
            return View();
        }

        // POST: Candles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CandleId,TypeId,ScentId,LabelId,Price,Discount,SizeId,IsFeatured,Photo1,Photo2,Photo3,Photo4,Photo5,Notes")] Candle candle)
        {
            if (ModelState.IsValid)
            {
                db.Candles.Add(candle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LabelId = new SelectList(db.Labels, "LabelId", "LabelDesc", candle.LabelId);
            ViewBag.TypeId = new SelectList(db.Products, "TypeId", "ProductName", candle.TypeId);
            ViewBag.ScentId = new SelectList(db.Scents, "ScentId", "ScentName", candle.ScentId);
            ViewBag.SizeId = new SelectList(db.Sizes, "SizeId", "SizeDesc", candle.SizeId);
            return View(candle);
        }

        // GET: Candles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candle candle = db.Candles.Find(id);
            if (candle == null)
            {
                return HttpNotFound();
            }
            ViewBag.LabelId = new SelectList(db.Labels, "LabelId", "LabelDesc", candle.LabelId);
            ViewBag.TypeId = new SelectList(db.Products, "TypeId", "ProductName", candle.TypeId);
            ViewBag.ScentId = new SelectList(db.Scents, "ScentId", "ScentName", candle.ScentId);
            ViewBag.SizeId = new SelectList(db.Sizes, "SizeId", "SizeDesc", candle.SizeId);
            return View(candle);
        }

        // POST: Candles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CandleId,TypeId,ScentId,LabelId,Price,Discount,SizeId,IsFeatured,Photo1,Photo2,Photo3,Photo4,Photo5,Notes")] Candle candle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LabelId = new SelectList(db.Labels, "LabelId", "LabelDesc", candle.LabelId);
            ViewBag.TypeId = new SelectList(db.Products, "TypeId", "ProductName", candle.TypeId);
            ViewBag.ScentId = new SelectList(db.Scents, "ScentId", "ScentName", candle.ScentId);
            ViewBag.SizeId = new SelectList(db.Sizes, "SizeId", "SizeDesc", candle.SizeId);
            return View(candle);
        }

        // GET: Candles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candle candle = db.Candles.Find(id);
            if (candle == null)
            {
                return HttpNotFound();
            }
            return View(candle);
        }

        // POST: Candles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Candle candle = db.Candles.Find(id);
            db.Candles.Remove(candle);
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
