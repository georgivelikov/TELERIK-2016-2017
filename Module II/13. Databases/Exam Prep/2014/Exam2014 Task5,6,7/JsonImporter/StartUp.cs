using System.Collections.Generic;
using System.IO;
using System.Linq;

using Cars.Data;
using Cars.Models;

using JsonImporter.JsonModels;

using Newtonsoft.Json;

namespace JsonImporter
{
    public class StartUp
    {
        public static void Main()
        {
            //string[] dirs = Directory.GetDirectories(@"c:\", "p*"); //https://msdn.microsoft.com/en-us/library/6ff71z1w(v=vs.110).aspx

            var file0 = File.ReadAllText("../../../Data.Json.Files/data.0.json");
            var file1 = File.ReadAllText("../../../Data.Json.Files/data.1.json");
            var file2 = File.ReadAllText("../../../Data.Json.Files/data.2.json");
            var file3 = File.ReadAllText("../../../Data.Json.Files/data.3.json");
            var file4 = File.ReadAllText("../../../Data.Json.Files/data.4.json");

            var fileCollection = new List<string>() { file0, file1, file2, file3, file4 };
            //var fileCollection = new List<string>() { file0 };

            var carsCollection = new List<JsonCar>();

            foreach (var fileContent in fileCollection)
            {
                var fileCars = JsonConvert.DeserializeObject<IEnumerable<JsonCar>>(fileContent);
                carsCollection.AddRange(fileCars);
            }

            var db = new CarsDbContext();
            db.Configuration.AutoDetectChangesEnabled = false;
            db.Configuration.ValidateOnSaveEnabled = false;

            var carCounter = 0;

            foreach (var car in carsCollection)
            {
                var city = db.Cities.FirstOrDefault(c => c.Name == car.Dealer.City);

                if (city == null)
                {
                    city = new City() { Name = car.Dealer.City };
                }

                var dealer = db.Dealers.FirstOrDefault(d => d.Name == car.Dealer.Name);

                if (dealer == null)
                {
                    dealer = new Dealer() { Name = car.Dealer.Name };
                }

                var manufacturer = db.Manufacturers.FirstOrDefault(m => m.Name == car.ManufacturerName);

                if (manufacturer == null)
                {
                    manufacturer = new Manufacturer() { Name = car.ManufacturerName };
                }

                var model = car.Model;
                var price = car.Price;
                var year = car.Year;
                var transmissonType = (TransmissionType)car.TransmissionType;
                
                if (!dealer.Cities.Contains(city))
                {
                    dealer.Cities.Add(city);
                }

                if (!city.Dealers.Contains(dealer))
                {
                    city.Dealers.Add(dealer);
                }

                var dataCar = new Car()
                                  {
                                      Model = model,
                                      Price = price,
                                      Year = year,
                                      Manufacturer = manufacturer,
                                      Dealer = dealer,
                                      TransmissionType = transmissonType
                                  };

                db.Cars.Add(dataCar);

                db.SaveChanges();

                if (carCounter % 100 == 0)
                {
                    db = new CarsDbContext();
                    db.Configuration.AutoDetectChangesEnabled = false;
                    db.Configuration.ValidateOnSaveEnabled = false;
                }
            }

            db.Configuration.AutoDetectChangesEnabled = true;
            db.Configuration.ValidateOnSaveEnabled = true;
        }
    }
}
