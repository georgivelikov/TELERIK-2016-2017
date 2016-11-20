using System;

using Superheroes.Models;

namespace Superheroes.Data.Contracts
{
    public interface ISuperheroesDataProvider : IDisposable
    {
        IGenericRepository<Superhero> Superheroes { get; set; }

        IGenericRepository<Power> Powers { get; set; }

        IGenericRepository<City> Cities { get; set; }

        IGenericRepository<Country> Countries { get; set; }

        IGenericRepository<Planet> Planets { get; set; }

        IGenericRepository<Fraction> Fractions { get; set; }

        IGenericRepository<Relationship> Relationships { get; set; }

        void Commit();
    }
}
