using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using CommodityAPI.Models;
using System.Net;
namespace CommodityAPI.Controllers
{
    public class UserProfileController : ApiController
    {
        // GET /api/userprofile
        CommodityAPIContext db = new CommodityAPIContext();
        public UserProfileController()
        {
            db.Configuration.LazyLoadingEnabled = false;
            db.Configuration.ProxyCreationEnabled = false;

        }
        public IEnumerable<UserProfile> Get()
        {
            return db.UserProfiles.ToList();
        }

        // GET /api/userprofile/5
        public UserProfile Get(int id)
        {
            return db.UserProfiles.Single(p => p.UserID == id);
        }

        // POST /api/userprofile
        public HttpResponseMessage<UserProfile> Post(UserProfile value)
        {
            
            db.UserProfiles.Add(value);
            db.SaveChanges();

            var response = new HttpResponseMessage<UserProfile>(value, HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, "/api/UserProfile/" + value.UserID);
            return response;
        }

        // PUT /api/userprofile/5
        public void Put(int id, string value)
        {
        }

        // DELETE /api/userprofile/5
        public void Delete(int id)
        {
        }
    }
}
