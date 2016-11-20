using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Company.DataGenerator;

namespace AddingSampleData.Importers
{
    public class StorageDeviceImporter : Importer
    {
        public StorageDeviceImporter(ComputersDbEntities db)
            : base(db)
        {
        }

        public override void Import(int count)
        {
            var modelsIds = this.Database.Models.Where(m => m.ModelType.Type == "Storage Device").Select(m => m.Id).ToList();

            for (int i = 0; i < count / 4; i++)
            {
                var modelId = modelsIds[RandomGenerator.Instance.GetRandomNumber(0, modelsIds.Count - 1)];
                var memory = RandomGenerator.Instance.GetRandomNumber(50, 500);
                var sdType = this.Database.StorageDeviceTypes.FirstOrDefault(s => s.Type == "SSD");
                var sd = new StorageDevice() { Size = memory, ModelId = modelId, StorageDeviceType = sdType };

                this.Database.StorageDevices.Add(sd);
            }

            for (int i = 0; i < (count - count / 4); i++)
            {
                var modelId = modelsIds[RandomGenerator.Instance.GetRandomNumber(0, modelsIds.Count - 1)];
                var memory = RandomGenerator.Instance.GetRandomNumber(50, 500);
                var sdType = this.Database.StorageDeviceTypes.FirstOrDefault(s => s.Type == "HDD");
                var sd = new StorageDevice() { Size = memory, ModelId = modelId, StorageDeviceType = sdType };

                this.Database.StorageDevices.Add(sd);
            }


            this.Database.SaveChanges();
        }
    }
}
