using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using Superheroes.Data.Contracts;
using Superheroes.Models;

namespace Superheroes.Data.Models
{
    public class SuperheroesDbContext : DbContext, ISuperheroesDbContext
    {
        public SuperheroesDbContext()
            :base("SuperheroesDb")
        {
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.ValidateOnSaveEnabled = false;
        }

        public IDbSet<Superhero> Superheroes { get; set; }

        public IDbSet<Power> Powers { get; set; }

        public IDbSet<City> Cities { get; set; }

        public IDbSet<Country> Countries { get; set; }

        public IDbSet<Planet> Planets { get; set; }

        public IDbSet<Fraction> Fractions { get; set; }

        public IDbSet<Relationship> Relationships { get; set; }

        public IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new void Dispose()
        {
            base.Dispose();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
