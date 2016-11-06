namespace Cars.Data
{
    using System.Data.Entity;

    using Cars.Models;

    public class CarsDbContext : DbContext
    {
        public CarsDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Dealer> Dealers { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dealer>().Property(dealer => dealer.Name).IsUnicode(true);
        }
    }
}
