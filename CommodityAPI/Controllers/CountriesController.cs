using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using CommodityAPI.Models;
using System.Net;

namespace CommodityAPI.Controllers
{
    public class CountriesController : ApiController
    {
        // GET /api/countries
        public CommodityAPIContext db = new CommodityAPIContext();
        public CountriesController()
        {
            db.Configuration.ProxyCreationEnabled = false;
            db.Configuration.LazyLoadingEnabled = false;
        }
        public IEnumerable<Country> Get()
        {
            return db.Countries.ToList();
        }

        // GET /api/countries/5
        public Country Get(int id)
        {
            return db.Countries.Find(id);
        }

        // POST /api/countries
        public HttpResponseMessage<Country> Post(Country value)
        {

            db.Countries.Add(value);
            db.SaveChanges();
            var response = new HttpResponseMessage<Country>(value, HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, "/api/Countries/" + value.CountryID);
            return response;
        }

        // PUT /api/countries/5
        public void Put(int id, string value)
        {
        }

        // DELETE /api/countries/5
        public void Delete(int id)
        {
        }
    }
}
