using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AddingSampleData.Importers;

namespace AddingSampleData
{
    public class Program
    {
        public static void Main()
        {
            var db = new ComputersDbEntities();

            //var compTypesImporter = new ComputerTypesImporter(db);
            //compTypesImporter.Import(0);

            //var gpuTypesImporter = new GpuTypeImporter(db);
            //gpuTypesImporter.Import(0);

            //var sdTpesImporter = new StorageDeviceTypesImporter(db);
            //sdTpesImporter.Import(0);

            //var modelTypesImporter = new ModelTypesImporter(db);
            //modelTypesImporter.Import(0);

            //var vendorImporter = new VendorImporter(db);
            //vendorImporter.Import(10);

            //var modelImporter = new ModelsImporter(db);
            //modelImporter.Import(100);

            //var cpuImporter = new CpuImporter(db);
            //cpuImporter.Import(10);

            //var computerImporter = new ComputerImporter(db);
            //computerImporter.Import(51);

            //var sdImporter = new StorageDeviceImporter(db);
            //sdImporter.Import(32);

            //var gpuImporter = new GpuImporter(db);
            //gpuImporter.Import(15);

            //var gpusComputersImporter = new ComputersGpusImporter(db);
            //gpusComputersImporter.Import(100);
        }
    }
}
