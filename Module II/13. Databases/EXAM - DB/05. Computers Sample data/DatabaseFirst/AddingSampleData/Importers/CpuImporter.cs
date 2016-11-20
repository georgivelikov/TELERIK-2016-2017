using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Company.DataGenerator;

namespace AddingSampleData.Importers
{
    public class CpuImporter : Importer
    {
        public CpuImporter(ComputersDbEntities db)
            : base(db)
        {
        }

        public override void Import(int count)
        {
            var cpuModelsId = this.Database.Models.Where(m => m.ModelType.Type == "CPU").Select(m => m.Id).ToList();

            for (int i = 0; i < count; i++)
            {
                var cpuModelId = cpuModelsId[RandomGenerator.Instance.GetRandomNumber(0, cpuModelsId.Count - 1)];
                var cores = RandomGenerator.Instance.GetRandomNumber(1, 8);
                var clockCycles = RandomGenerator.Instance.GetRandomNumber(1, 6);

                var cpu = new Cpu() { ModelId = cpuModelId, NumberOfCores = cores, ClockCycles =  clockCycles };
                this.Database.Cpus.Add(cpu);
            }

            this.Database.SaveChanges();
        }
    }
}
