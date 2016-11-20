using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddingSampleData.Importers
{
    public class GpuTypeImporter : Importer
    {
        public GpuTypeImporter(ComputersDbEntities db)
            : base(db)
        {
        }

        public override void Import(int count)
        {
            var gpuType1 = new GpuType() { Type = "Internal" };
            var gpuType2 = new GpuType() { Type = "External" };

            this.Database.GpuTypes.Add(gpuType1);
            this.Database.GpuTypes.Add(gpuType2);

            this.Database.SaveChanges();
        }
    }
}
