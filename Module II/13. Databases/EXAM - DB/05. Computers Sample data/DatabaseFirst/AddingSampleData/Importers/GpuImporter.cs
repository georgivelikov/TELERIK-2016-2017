using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Company.DataGenerator;

namespace AddingSampleData.Importers
{
    public class GpuImporter : Importer
    {
        public GpuImporter(ComputersDbEntities db)
            : base(db)
        {
        }

        public override void Import(int count)
        {
            var modelsIds = this.Database.Models.Where(m => m.ModelType.Type == "GPU").Select(m => m.Id).ToList();

            for (int i = 0; i < count / 3; i++)
            {
                var modelId = modelsIds[RandomGenerator.Instance.GetRandomNumber(0, modelsIds.Count - 1)];
                var memory = RandomGenerator.Instance.GetRandomNumber(2, 16);
                var gpuType = this.Database.GpuTypes.FirstOrDefault(s => s.Type == "Internal");
                var gpu = new Gpu() { Memory = memory, ModelId = modelId, GpuType = gpuType };

                this.Database.Gpus.Add(gpu);
            }

            for (int i = 0; i < (count - count / 3); i++)
            {
                var modelId = modelsIds[RandomGenerator.Instance.GetRandomNumber(0, modelsIds.Count - 1)];
                var memory = RandomGenerator.Instance.GetRandomNumber(2, 16);
                var gpuType = this.Database.GpuTypes.FirstOrDefault(s => s.Type == "External");
                var gpu = new Gpu() { Memory = memory, ModelId = modelId, GpuType = gpuType };

                this.Database.Gpus.Add(gpu);
            }

            this.Database.SaveChanges();
        }
    }
}
