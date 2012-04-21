using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using CommodityAPI.Models;
using System.Net;

namespace CommodityAPI.Controllers
{
    public class CountryController : ApiController
    {
        // GET /api/country
        CommodityAPIContext db = new CommodityAPIContext();
        public CountryController()
        {
            db.Configuration.LazyLoadingEnabled = false;
            db.Configuration.ProxyCreationEnabled = false;
        }
        public IEnumerable<Country> Get()
        {
            return db.Countries.ToList();
        }

        // GET /api/country/5
        public Country Get(int id)
        {
            return db.Countries.Single(option => option.CountryID == id);
        }

        // POST /api/country
        public HttpResponseMessage<Country> Post(Country value)
        {
            db.Countries.Add(value);
            db.SaveChanges();
            var response = new HttpResponseMessage<Country>(value, HttpStatusCode.Created);
            response.Headers.Location=new Uri(Request.RequestUri, "/api/Country/" + value.CountryID);
            return response;
        }

        // PUT /api/country/5
        public void Put(int id, string value)
        {
        }

        // DELETE /api/country/5
        public void Delete(int id)
        {
        }
    }
}
