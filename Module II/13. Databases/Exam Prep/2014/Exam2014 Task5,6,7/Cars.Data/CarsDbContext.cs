using System.Data.Entity;

using Cars.Data.Migrations;
using Cars.Models;

namespace Cars.Data
{
    public class CarsDbContext : DbContext
    {
        public CarsDbContext() 
            : base("CarsDb")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarsDbContext, Configuration>());
        }

        public virtual IDbSet<Car> Cars { get; set; }

        public virtual IDbSet<Manufacturer> Manufacturers { get; set; }

        public virtual IDbSet<Dealer> Dealers { get; set; }

        public virtual IDbSet<City> Cities { get; set; }
    }
}
