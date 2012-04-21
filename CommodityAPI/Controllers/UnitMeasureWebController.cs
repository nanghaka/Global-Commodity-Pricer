using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using CommodityAPI.Models;

namespace CommodityAPI.Controllers
{
    public class UnitMeasureWebController : Controller
    {
        private CommodityAPIContext db = new CommodityAPIContext();

        //
        // GET: /CommodityUnitWeb/

        public ActionResult Index()
        {
            return View(db.UnitMeasures.ToList());
        }

        //
        // GET: /CommodityUnitWeb/Details/5

        public ActionResult Details(int id = 0)
        {
            UnitMeasure commodityunit = db.UnitMeasures.Find(id);
            if (commodityunit == null)
            {
                return HttpNotFound();
            }
            return View(commodityunit);
        }

        //
        // GET: /CommodityUnitWeb/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CommodityUnitWeb/Create

        [HttpPost]
        public ActionResult Create(UnitMeasure commodityunit)
        {
            
            if (ModelState.IsValid)
            {
                db.UnitMeasures.Add(commodityunit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(commodityunit);
        }

        //
        // GET: /CommodityUnitWeb/Edit/5

        public ActionResult Edit(int id = 0)
        {
            UnitMeasure commodityunit = db.UnitMeasures.Find(id);
            if (commodityunit == null)
            {
                return HttpNotFound();
            }
            return View(commodityunit);
        }

        //
        // POST: /CommodityUnitWeb/Edit/5

        [HttpPost]
        public ActionResult Edit(UnitMeasure commodityunit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commodityunit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(commodityunit);
        }

        //
        // GET: /CommodityUnitWeb/Delete/5

        public ActionResult Delete(int id = 0)
        {
            UnitMeasure commodityunit = db.UnitMeasures.Find(id);
            if (commodityunit == null)
            {
                return HttpNotFound();
            }
            return View(commodityunit);
        }

        //
        // POST: /CommodityUnitWeb/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            UnitMeasure commodityunit = db.UnitMeasures.Find(id);
            db.UnitMeasures.Remove(commodityunit);
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