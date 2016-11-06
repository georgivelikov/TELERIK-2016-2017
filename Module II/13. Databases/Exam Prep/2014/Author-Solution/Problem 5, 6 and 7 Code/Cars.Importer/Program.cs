namespace Cars.Importer
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    using Cars.Data;
    using Cars.Data.Migrations;
    using Cars.Importer.GeneratingJsonFiles;
    using Cars.Models;

    using Newtonsoft.Json;

    using Car = Cars.Importer.Models.Car;

    internal class Program
    {
        private static void Main()
        {
            ImportData();
        }

        private static void ImportData()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarsDbContext, Configuration>());

            var cars = new List<Car>();

            var files = Directory.GetFiles(Environment.CurrentDirectory).Where(fileName => fileName.EndsWith(".json")).ToList();

            foreach (var file in files)
            {
                var fileContent = File.ReadAllText(file);
                var fileCars = JsonConvert.DeserializeObject<IEnumerable<Car>>(fileContent);
                cars.AddRange(fileCars);
                Console.WriteLine("{0} read.", file);
            }

            var manufacturerNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var cityNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var dealerNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var car in cars)
            {
                manufacturerNames.Add(car.ManufacturerName);
                cityNames.Add(car.Dealer.City);
                dealerNames.Add(car.Dealer.Name);
            }

            var db = new CarsDbContext();
            db.Configuration.AutoDetectChangesEnabled = false;

            // Add cities
            Console.WriteLine("Adding cities...");
            foreach (var cityName in cityNames)
            {
                db.Cities.AddOrUpdate(c => c.Name, new City { Name = cityName });
            }

            db.SaveChanges();
            Console.WriteLine("Cities added.");

            // Add manufacturers
            Console.WriteLine("Adding manufacturers...");
            foreach (var manufacturerName in manufacturerNames)
            {
                db.Manufacturers.AddOrUpdate(m => m.Name, new Manufacturer { Name = manufacturerName });
            }

            db.SaveChanges();
            Console.WriteLine("Manufacturers added.");

            // Add dealers
            Console.WriteLine("Adding dealers...");
            foreach (var dealerName in dealerNames)
            {
                db.Dealers.AddOrUpdate(d => d.Name, new Dealer { Name = dealerName });
            }

            db.SaveChanges();
            Console.WriteLine("Dealers added.");

            // Add cars
            Console.Write("Adding cars");
            for (int carIndex = 0; carIndex < cars.Count; carIndex++)
            {
                var car = cars[carIndex];
                var databaseCarCity = db.Cities.FirstOrDefault(x => x.Name == car.Dealer.City);
                if (databaseCarCity == null)
                {
                    throw new ArgumentException("Invalid city name!");
                }

                var databaseCar = new Cars.Models.Car
                                      {
                                          Dealer = db.Dealers.FirstOrDefault(d => d.Name == car.Dealer.Name),
                                          Manufacturer =
                                              db.Manufacturers.FirstOrDefault(x => x.Name == car.ManufacturerName),
                                          Model = car.Model,
                                          Price = car.Price,
                                          TransmissionType = car.TransmissionType,
                                          Year = (short)car.Year,
                                      };

                db.Configuration.AutoDetectChangesEnabled = true;
                if (!databaseCar.Dealer.Cities.Any(c => c.Name == databaseCarCity.Name))
                {
                    databaseCarCity.Dealers.Add(databaseCar.Dealer);
                }

                db.Cars.Add(databaseCar);

                if (carIndex % 100 == 0)
                {
                    db.SaveChanges();
                    Console.Write(".");
                }

                db.Configuration.AutoDetectChangesEnabled = false;
            }

            Console.WriteLine();

            db.SaveChanges();
            Console.WriteLine("Cars added.");
        }

        private static void GenerateJsonFiles()
        {
            IJsonFilesGenerator jsonFilesGenerator = new JsonFilesGenerator();
            jsonFilesGenerator.Generate(4, RandomGenerator.Instance);
        }
    }
}
