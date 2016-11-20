using Superheroes.Data.Contracts;
using Superheroes.Models;

namespace Superheroes.Data.Models
{
    public class SuperheroesDataProvider : ISuperheroesDataProvider
    {
        private IUnitOfWork unitOfWork;

        public SuperheroesDataProvider(
            IUnitOfWork unitOfWork,
            IGenericRepository<Superhero> superheroes,
            IGenericRepository<City> cities,
            IGenericRepository<Country> countries,
            IGenericRepository<Planet> planets,
            IGenericRepository<Fraction> fractions,
            IGenericRepository<Relationship> relationships,
            IGenericRepository<Power> powers
            )
        {
            this.unitOfWork = unitOfWork;
            this.Superheroes = superheroes;
            this.Cities = cities;
            this.Countries = countries;
            this.Planets = planets;
            this.Fractions = fractions;
            this.Relationships = relationships;
            this.Powers = powers;
        }

        public IGenericRepository<Superhero> Superheroes { get; set; }

        public IGenericRepository<Power> Powers { get; set; }

        public IGenericRepository<City> Cities { get; set; }

        public IGenericRepository<Country> Countries { get; set; }

        public IGenericRepository<Planet> Planets { get; set; }

        public IGenericRepository<Fraction> Fractions { get; set; }

        public IGenericRepository<Relationship> Relationships { get; set; }

        public void Commit()
        {
            this.unitOfWork.SaveChanges();;
        }

        public void Dispose()
        {
            this.unitOfWork.Dispose();
        }
    }
}
