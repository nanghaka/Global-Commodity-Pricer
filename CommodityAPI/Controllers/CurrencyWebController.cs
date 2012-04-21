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
    public class CurrencyWebController : Controller
    {
        private CommodityAPIContext db = new CommodityAPIContext();

        //
        // GET: /CurrencyWeb/

        public ActionResult Index()
        {
            return View(db.Currencies.ToList());
        }

        //
        // GET: /CurrencyWeb/Details/5

        public ActionResult Details(int id = 0)
        {
            Currency currency = db.Currencies.Find(id);
            if (currency == null)
            {
                return HttpNotFound();
            }
            return View(currency);
        }

        //
        // GET: /CurrencyWeb/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CurrencyWeb/Create

        [HttpPost]
        public ActionResult Create(Currency currency)
        {
            if (ModelState.IsValid)
            {
                db.Currencies.Add(currency);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(currency);
        }

        //
        // GET: /CurrencyWeb/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Currency currency = db.Currencies.Find(id);
            if (currency == null)
            {
                return HttpNotFound();
            }
            return View(currency);
        }

        //
        // POST: /CurrencyWeb/Edit/5

        [HttpPost]
        public ActionResult Edit(Currency currency)
        {
            if (ModelState.IsValid)
            {
                db.Entry(currency).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(currency);
        }

        //
        // GET: /CurrencyWeb/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Currency currency = db.Currencies.Find(id);
            if (currency == null)
            {
                return HttpNotFound();
            }
            return View(currency);
        }

        //
        // POST: /CurrencyWeb/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Currency currency = db.Currencies.Find(id);
            db.Currencies.Remove(currency);
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