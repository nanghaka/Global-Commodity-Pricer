using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CommodityAPI.Models
{
    public class CommodityAPIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<CommodityAPI.Models.CommodityAPIContext>());

        public DbSet<Commodity> Commodities { get; set; }

        public DbSet<UnitMeasure> UnitMeasures { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
            
        }

        public DbSet<Country> Countries { get; set; }
    }
}
