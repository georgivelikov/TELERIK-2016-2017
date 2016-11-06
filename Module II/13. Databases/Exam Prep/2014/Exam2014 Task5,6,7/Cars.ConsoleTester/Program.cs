using System.Linq;

using Cars.Data;
using Cars.Models;

namespace Cars.ConsoleTester
{
    public class Program
    {
        public static void Main()
        {
            var carsDb = new CarsDbContext();

            carsDb.Cities.Count();

        }
    }
}
