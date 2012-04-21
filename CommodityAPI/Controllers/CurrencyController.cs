using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using CommodityAPI.Models;
using System.Net;
namespace CommodityAPI.Controllers
{
    public class CurrencyController : ApiController
    {
        // GET /api/currency
        CommodityAPIContext db = new CommodityAPIContext();
        public CurrencyController ()
        {
            db.Configuration.ProxyCreationEnabled = false;
            db.Configuration.LazyLoadingEnabled = false;

        }
        public IEnumerable<Currency> Get()
        {
            return db.Currencies.ToList();
        }

        // GET /api/currency/5
        public Currency Get(int id)
        {
            return db.Currencies.Single(option => option.CurrencyID == id);
        }

        // POST /api/currency
        public HttpResponseMessage<Currency>Post(Currency value)
        {
            db.Currencies.Add(value);
            db.SaveChanges();
            var response = new HttpResponseMessage<Currency>(value, HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, "/api/Currency/" + value.CurrencyID);
            return response;
        }

        // PUT /api/currency/5
        public void Put(int id, string value)
        {
        }

        // DELETE /api/currency/5
        public void Delete(int id)
        {
        }
    }
}
