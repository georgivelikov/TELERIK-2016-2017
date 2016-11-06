using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1___Bunnies.Engine
{
    using System.IO;

    using Enums;

    using Interfaces;

    using Models;

    using Writers;

    public class BunniesEngine
    {
        //private const string BunniesFilePath = @"..\..\bunnies.txt";

        public IEnumerable<Bunny> CreateListOfBunnies()
        {
            var list = new List<Bunny>
                              {
                                  new Bunny("Leonid", 1, FurType.NotFluffy),
                                  new Bunny("Rasputin", 2, FurType.ALittleFluffy),
                                  new Bunny("Tiberii", 3, FurType.ALittleFluffy),
                                  new Bunny("Neron", 1, FurType.ALittleFluffy),
                                  new Bunny("Klavdii", 3, FurType.Fluffy),
                                  new Bunny("Vespasian", 3, FurType.Fluffy),
                                  new Bunny("Domician", 4, FurType.FluffyToTheLimit),
                                  new Bunny("Tit", 2, FurType.FluffyToTheLimit)
                              };
            return list;
        }

        public IWriter CreateConsoleWriter()
        {
            return new ConsoleWriter();
        }

        public void IntroduceBunnies(IEnumerable<Bunny> bunniesList, IWriter bunniesWriter)
        {
            foreach (var bunny in bunniesList)
            {
                bunny.Introduce(bunniesWriter);
            }
        }

        public void SaveBunniesToFile(string bunniesFilePath, IEnumerable<Bunny> bunniesList, IWriter writer)
        {
            if (!File.Exists(bunniesFilePath) || !bunniesFilePath.Contains(".txt"))
            {
                writer.WriteLine("File for saving not found!");
                return;
            }

            StreamWriter streamWriter = new StreamWriter(bunniesFilePath);

            using (streamWriter)
            {
                foreach (var bunny in bunniesList)
                {
                    streamWriter.WriteLine(bunny.ToString());
                }
            }
        }

        public void CreateFileForSaving(string bunniesFilePath)
        {
            var fileStream = File.Create(bunniesFilePath);
            fileStream.Close();
        }
    }
}
