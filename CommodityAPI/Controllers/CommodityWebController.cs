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
        // GET: /CommdityWeb/

        public ActionResult Index()
        {
            var commodities = db.Commodities.Include(c => c.Units);
            return View(commodities.ToList());
        }

        //
        // GET: /CommdityWeb/Details/5

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
        // GET: /CommdityWeb/Create

        public ActionResult Create()
        {
            ViewBag.CommodityUnitID = new SelectList(db.UnitMeasures, "UnitMeasureID", "ComodityUnitName");
            return View();
        }

        //
        // POST: /CommdityWeb/Create

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

            ViewBag.CommodityUnitID = new SelectList(db.UnitMeasures, "UnitMeasureID", "UnitName", commodity.UnitMeasureID);
            return View(commodity);
        }

        //
        // GET: /CommdityWeb/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Commodity commodity = db.Commodities.Find(id);
            if (commodity == null)
            {
                return HttpNotFound();
            }
            ViewBag.CommodityUnitID = new SelectList(db.UnitMeasures, "UnitMeasureID", "UnitName", commodity.UnitMeasureID);
            return View(commodity);
        }

        //
        // POST: /CommdityWeb/Edit/5

        [HttpPost]
        public ActionResult Edit(Commodity commodity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commodity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CommodityUnitID = new SelectList(db.UnitMeasures, "UnitMeasureID", "UnitName", commodity.UnitMeasureID);
            return View(commodity);
        }

        //
        // GET: /CommdityWeb/Delete/5

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
        // POST: /CommdityWeb/Delete/5

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