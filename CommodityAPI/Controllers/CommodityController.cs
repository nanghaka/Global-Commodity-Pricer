using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using CommodityAPI.Models;
using System.Net;

namespace CommodityAPI.Controllers
{
    public class CommodityController : ApiController
    {
        CommodityAPIContext db = new CommodityAPIContext();
        public CommodityController()
        {
            db.Configuration.ProxyCreationEnabled = false;
            db.Configuration.LazyLoadingEnabled = false;
        }
        // GET /api/commodity
        public IEnumerable<Commodity> Get()
        {
            return db.Commodities.ToList();
        }

        // GET /api/commodity/5
        public Commodity Get(int id)
        {
            return db.Commodities.Single(option => option.CommodityID == id);
        }

        // POST /api/commodity
        public HttpResponseMessage<Commodity> Post(Commodity value)
        {
            value.DateTimeSubmitted = DateTime.Now;
            db.Commodities.Add(value);
            db.SaveChanges();

            var response = new HttpResponseMessage<Commodity>(value, HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, "/api/Commodity/" + value.CommodityID);
            return response;
        }

        // PUT /api/commodity/5
        public void Put(int id, string value)
        {
        }

        // DELETE /api/commodity/5
        public void Delete(int id)
        {
        }
    }
}
