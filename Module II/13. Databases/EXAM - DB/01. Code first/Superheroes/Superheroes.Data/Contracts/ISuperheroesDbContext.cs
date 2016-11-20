using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using Superheroes.Models;

namespace Superheroes.Data.Contracts
{
    public interface ISuperheroesDbContext : IDisposable
    {
        IDbSet<Superhero> Superheroes { get; set; }

        IDbSet<Power> Powers { get; set; }

        IDbSet<City> Cities { get; set; }

        IDbSet<Country> Countries { get; set; }

        IDbSet<Planet> Planets { get; set; }

        IDbSet<Fraction> Fractions { get; set; }

        IDbSet<Relationship> Relationships { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void SaveChanges();

    }
    
}
