using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommodityAPI.Models;

namespace CommodityAPI.Controllers
{
    public class CommodityWebController : Controller
    {
        private CommodityAPIContext db = new CommodityAPIContext();

        //
        // GET: /CommodityWeb/

        public ActionResult Index()
        {
            var commodities = db.Commodities.Include(c => c.Units);
            return View(commodities.ToList());
        }

        //
        // GET: /CommodityWeb/Details/5

        public ActionResult Details(int id = 0)
        {
            Commodity commodity = db.Commodities.Find(id);
            if (commodity == null)
            {
                return HttpNotFound();
            }
            return View(commodity);
        }

        //
        // GET: /CommodityWeb/Create

        public ActionResult Create()
        {
            ViewBag.UnitMeasureID = new SelectList(db.UnitMeasures, "UnitMeasureID", "UnitName");
            return View();
        }

        //
        // POST: /CommodityWeb/Create

        [HttpPost]
        public ActionResult Create(Commodity commodity)
        {
            commodity.DateTimeSubmitted = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Commodities.Add(commodity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UnitMeasureID = new SelectList(db.UnitMeasures, "UnitMeasureID", "UnitName", commodity.UnitMeasureID);
            return View(commodity);
        }

        //
        // GET: /CommodityWeb/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Commodity commodity = db.Commodities.Find(id);
            if (commodity == null)
            {
                return HttpNotFound();
            }
            ViewBag.UnitMeasureID = new SelectList(db.UnitMeasures, "UnitMeasureID", "UnitName", commodity.UnitMeasureID);
            return View(commodity);
        }

        //
        // POST: /CommodityWeb/Edit/5

        [HttpPost]
        public ActionResult Edit(Commodity commodity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commodity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UnitMeasureID = new SelectList(db.UnitMeasures, "UnitMeasureID", "UnitName", commodity.UnitMeasureID);
            return View(commodity);
        }

        //
        // GET: /CommodityWeb/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Commodity commodity = db.Commodities.Find(id);
            if (commodity == null)
            {
                return HttpNotFound();
            }
            return View(commodity);
        }

        //
        // POST: /CommodityWeb/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Commodity commodity = db.Commodities.Find(id);
            db.Commodities.Remove(commodity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}