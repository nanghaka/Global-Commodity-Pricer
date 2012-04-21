using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using CommodityAPI.Models;
using System.Net;
namespace CommodityAPI.Controllers
{
    public class UnitMeasureController : ApiController
    {
        // GET /api/unitmeasure
        CommodityAPIContext db = new CommodityAPIContext();
        public UnitMeasureController()
        {
            db.Configuration.LazyLoadingEnabled = false;
            db.Configuration.ProxyCreationEnabled = false;
        }
        public IEnumerable<UnitMeasure> Get()
        {
            return db.UnitMeasures.ToList();
        }

        // GET /api/unitmeasure/5
        public UnitMeasure Get(int id)
        {
            return db.UnitMeasures.Find(id);
        }

        // POST /api/unitmeasure
        public HttpResponseMessage<UnitMeasure> Post(UnitMeasure value)
        {
           

            db.UnitMeasures.Add(value);
            db.SaveChanges();
            var response = new HttpResponseMessage<UnitMeasure>(value, HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, "/api/UnitMeasure/" + value.UnitMeasureID);
            return response;
        }

        // PUT /api/unitmeasure/5
        public void Put(int id, string value)
        {
        }

        // DELETE /api/unitmeasure/5
        public void Delete(int id)
        {
        }
    }
}
