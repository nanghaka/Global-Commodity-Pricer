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
    public class UnitMeasureWebController : Controller
    {
        private CommodityAPIContext db = new CommodityAPIContext();

        //
        // GET: /UnitMeasureWeb/

        public ActionResult Index()
        {
            return View(db.UnitMeasures.ToList());
        }

        //
        // GET: /UnitMeasureWeb/Details/5

        public ActionResult Details(int id = 0)
        {
            UnitMeasure unitmeasure = db.UnitMeasures.Find(id);
            if (unitmeasure == null)
            {
                return HttpNotFound();
            }
            return View(unitmeasure);
        }

        //
        // GET: /UnitMeasureWeb/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /UnitMeasureWeb/Create

        [HttpPost]
        public ActionResult Create(UnitMeasure unitmeasure)
        {
            if (ModelState.IsValid)
            {
                db.UnitMeasures.Add(unitmeasure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unitmeasure);
        }

        //
        // GET: /UnitMeasureWeb/Edit/5

        public ActionResult Edit(int id = 0)
        {
            UnitMeasure unitmeasure = db.UnitMeasures.Find(id);
            if (unitmeasure == null)
            {
                return HttpNotFound();
            }
            return View(unitmeasure);
        }

        //
        // POST: /UnitMeasureWeb/Edit/5

        [HttpPost]
        public ActionResult Edit(UnitMeasure unitmeasure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unitmeasure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unitmeasure);
        }

        //
        // GET: /UnitMeasureWeb/Delete/5

        public ActionResult Delete(int id = 0)
        {
            UnitMeasure unitmeasure = db.UnitMeasures.Find(id);
            if (unitmeasure == null)
            {
                return HttpNotFound();
            }
            return View(unitmeasure);
        }

        //
        // POST: /UnitMeasureWeb/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            UnitMeasure unitmeasure = db.UnitMeasures.Find(id);
            db.UnitMeasures.Remove(unitmeasure);
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