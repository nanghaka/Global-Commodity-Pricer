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
    public class CountryWebController : Controller
    {
        private CommodityAPIContext db = new CommodityAPIContext();

        //
        // GET: /CountryWeb/

        public ActionResult Index()
        {
            var countries = db.Countries.Include(c => c.Currencies);
            return View(countries.ToList());
        }

        //
        // GET: /CountryWeb/Details/5

        public ActionResult Details(int id = 0)
        {
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        //
        // GET: /CountryWeb/Create

        public ActionResult Create()
        {
            ViewBag.CurrencyID = new SelectList(db.Currencies, "CurrencyID", "CurrencyName");
            return View();
        }

        //
        // POST: /CountryWeb/Create

        [HttpPost]
        public ActionResult Create(Country country)
        {
            if (ModelState.IsValid)
            {
                db.Countries.Add(country);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CurrencyID = new SelectList(db.Currencies, "CurrencyID", "CurrencyName", country.CurrencyID);
            return View(country);
        }

        //
        // GET: /CountryWeb/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            ViewBag.CurrencyID = new SelectList(db.Currencies, "CurrencyID", "CurrencyName", country.CurrencyID);
            return View(country);
        }

        //
        // POST: /CountryWeb/Edit/5

        [HttpPost]
        public ActionResult Edit(Country country)
        {
            if (ModelState.IsValid)
            {
                db.Entry(country).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CurrencyID = new SelectList(db.Currencies, "CurrencyID", "CurrencyName", country.CurrencyID);
            return View(country);
        }

        //
        // GET: /CountryWeb/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        //
        // POST: /CountryWeb/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Country country = db.Countries.Find(id);
            db.Countries.Remove(country);
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