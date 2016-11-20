using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Company.DataGenerator;

namespace AddingSampleData.Importers
{
    public class ComputersGpusImporter : Importer
    {
        public ComputersGpusImporter(ComputersDbEntities db)
            : base(db)
        {
        }

        public override void Import(int count)
        {
            var gpusIds = this.Database.Gpus.Select(g => g.Id).ToList();
            var compsIds = this.Database.Computers.Select(c => c.Id).ToList();
            for (int i = 0; i < count; i++)
            {
                var gpuId = gpusIds[RandomGenerator.Instance.GetRandomNumber(0, gpusIds.Count - 1)];
                var compId = compsIds[RandomGenerator.Instance.GetRandomNumber(0, compsIds.Count - 1)];

                var comp = this.Database.Computers.FirstOrDefault(c => c.Id == compId);
                var gpu = this.Database.Gpus.FirstOrDefault(g => g.Id == gpuId);
                comp.Gpus.Add(gpu);
                gpu.Computers.Add(comp);
            }
            
        }
    }
}
