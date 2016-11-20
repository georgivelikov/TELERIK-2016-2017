using System.Data.Entity;

using Superheroes.Data.Migrations;
using Superheroes.Data.Models;
using Superheroes.Models;

namespace Superheroes.ConsoleClient
{
    public class StartUp
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SuperheroesDbContext, Configuration>());

            var db = new SuperheroesDbContext();
            var unitOfWork = new UnitOfWork(db);
            var superheroesRepo = new GenericRepository<Superhero>(db);
            var cityRepo = new GenericRepository<City>(db);
            var countriesRepo = new GenericRepository<Country>(db);
            var planetsRepo = new GenericRepository<Planet>(db);
            var relationRepo = new GenericRepository<Relationship>(db);
            var fractionRepo = new GenericRepository<Fraction>(db);
            var powerRepo = new GenericRepository<Power>(db);

            var dataProvider = new SuperheroesDataProvider(unitOfWork, superheroesRepo, cityRepo, countriesRepo, planetsRepo, fractionRepo, relationRepo, powerRepo);
            var importer = new JsonImporter.JsonImporter();

            importer.Import(dataProvider);


            var exporter = new XmlExporter.XmlExporter(dataProvider);

            exporter.ExportAllSuperheroes();
            exporter.ExportSupperheroesWithPower("Martial arts");
            exporter.ExportSuperheroesByCity("New York");
            exporter.ExportSuperheroDetails(1);
            exporter.ExportFractions();
            exporter.ExportFractionDetails(1);
        }
    }
}
