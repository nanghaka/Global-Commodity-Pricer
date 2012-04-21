using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CommodityAPI.Models
{
    public class CommodityAPIContext : DbContext
    {

        public DbSet<Commodity> Commodities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<UnitMeasure> UnitMeasures { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

       
       
    }
   
}