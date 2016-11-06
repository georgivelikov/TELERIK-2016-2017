namespace Cars.Importer.GeneratingJsonFiles
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Cars.Models;

    using Newtonsoft.Json;

    using Car = Cars.Importer.Models.Car;
    using Dealer = Cars.Importer.Models.Dealer;

    public class JsonFilesGenerator : IJsonFilesGenerator
    {
        public void Generate(int filesCount, IRandomGenerator random)
        {
            const int EntitiesPerFile = 3000;
            var manufacturers = random.GetRandomStrings(20, 7).ToList();
            var cities = random.GetRandomStrings(15, 8).ToList();
            var dealers = random.GetRandomStrings(20, 10).ToList();

            for (int i = 1; i <= filesCount; i++)
            {
                var data = new List<Car>();
                for (int j = 0; j < EntitiesPerFile; j++)
                {
                    var car = new Car
                                  {
                                      ManufacturerName = random.GetRandomElement(manufacturers),
                                      Model = random.GetRandomString(20),
                                      Price = random.GetRandomNumber(1000, 200000),
                                      TransmissionType =
                                          (random.GetRandomNumber(1, 3) == 1)
                                              ? TransmissionType.Automatic
                                              : TransmissionType.Manual,
                                      Year = (ushort)random.GetRandomNumber(1990, 2015),
                                      Dealer =
                                          new Dealer
                                              {
                                                  City = random.GetRandomElement(cities),
                                                  Name = random.GetRandomElement(dealers)
                                              }
                                  };

                    data.Add(car);
                }

                using (var writer = new StreamWriter(string.Format("data.{0}.json", i)))
                {
                    writer.Write(JsonConvert.SerializeObject(data));
                }
            }
        }
    }
}
