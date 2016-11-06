using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonImporter.JsonModels
{
    public class JsonCar
    {
        public int Year { get; set; }

        public int TransmissionType { get; set; }

        public string ManufacturerName { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public JsonDealer Dealer { get; set; }
    }
}
