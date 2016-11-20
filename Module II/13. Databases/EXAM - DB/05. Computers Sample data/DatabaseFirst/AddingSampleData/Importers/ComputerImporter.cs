using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Company.DataGenerator;

namespace AddingSampleData.Importers
{
    public class ComputerImporter : Importer
    {
        public ComputerImporter(ComputersDbEntities db)
            : base(db)
        {
        }

        public override void Import(int count)
        {
            var cpuIds = this.Database.Cpus.Select(c => c.Id).ToList();
            var modelsIds = this.Database.Models.Where(m => m.ModelType.Type == "Computer").Select(m => m.Id).ToList();

            for (int i = 0; i < count / 3; i++)
            {
                var cpuId = cpuIds[RandomGenerator.Instance.GetRandomNumber(0, cpuIds.Count - 1)];
                var modelId = modelsIds[RandomGenerator.Instance.GetRandomNumber(0, modelsIds.Count - 1)];
                var memory = RandomGenerator.Instance.GetRandomNumber(2, 16);
                var compType = this.Database.ComputerTypes.FirstOrDefault(c => c.Type == "Notebook");
                var comp = new Computer() { CpuId = cpuId, ModelId = modelId, Memory = memory, ComputerType = compType };

                this.Database.Computers.Add(comp);
            }

            for (int i = 0; i < count / 3; i++)
            {
                var cpuId = cpuIds[RandomGenerator.Instance.GetRandomNumber(0, cpuIds.Count - 1)];
                var modelId = modelsIds[RandomGenerator.Instance.GetRandomNumber(0, modelsIds.Count - 1)];
                var memory = RandomGenerator.Instance.GetRandomNumber(100, 1000);
                var compType = this.Database.ComputerTypes.FirstOrDefault(c => c.Type == "Desktop");
                var comp = new Computer() { CpuId = cpuId, ModelId = modelId, Memory = memory, ComputerType = compType };

                this.Database.Computers.Add(comp);
            }

            for (int i = 0; i < count / 3; i++)
            {
                var cpuId = cpuIds[RandomGenerator.Instance.GetRandomNumber(0, cpuIds.Count - 1)];
                var modelId = modelsIds[RandomGenerator.Instance.GetRandomNumber(0, modelsIds.Count - 1)];
                var memory = RandomGenerator.Instance.GetRandomNumber(100, 1000);
                var compType = this.Database.ComputerTypes.FirstOrDefault(c => c.Type == "Ultrabook");
                var comp = new Computer() { CpuId = cpuId, ModelId = modelId, Memory = memory, ComputerType = compType };

                this.Database.Computers.Add(comp);
            }

            this.Database.SaveChanges();
        }
    }
}
