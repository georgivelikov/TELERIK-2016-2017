using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Company.DataGenerator;

namespace AddingSampleData.Importers
{
    public class ModelsImporter : Importer
    {
        public ModelsImporter(ComputersDbEntities db)
            : base(db)
        {
        }

        public override void Import(int count)
        {
            var quaterCount = count / 4;
            var vendorIds = this.Database.Vendors.Select(d => d.Id).ToList();
            var computerModel = this.Database.ModelTypes.FirstOrDefault(m => m.Type == "Computer");
            var cpuModel = this.Database.ModelTypes.FirstOrDefault(m => m.Type == "CPU");
            var gpuModel = this.Database.ModelTypes.FirstOrDefault(m => m.Type == "GPU");
            var sdModel = this.Database.ModelTypes.FirstOrDefault(m => m.Type == "Storage Device");

            for (int i = 0; i < quaterCount; i++)
            {
                var vendorId = vendorIds[RandomGenerator.Instance.GetRandomNumber(0, vendorIds.Count - 1)];
                var name = RandomGenerator.Instance.GetRandomString(15);
                var model = new Model() { Name = name, VendorId = vendorId, ModelType = computerModel };
                this.Database.Models.Add(model);
            }

            for (int i = 0; i < quaterCount; i++)
            {
                var vendorId = vendorIds[RandomGenerator.Instance.GetRandomNumber(0, vendorIds.Count - 1)];
                var name = RandomGenerator.Instance.GetRandomString(15);
                var model = new Model() { Name = name, VendorId = vendorId, ModelType = cpuModel };
                this.Database.Models.Add(model);
            }

            for (int i = 0; i < quaterCount; i++)
            {
                var vendorId = vendorIds[RandomGenerator.Instance.GetRandomNumber(0, vendorIds.Count - 1)];
                var name = RandomGenerator.Instance.GetRandomString(15);
                var model = new Model() { Name = name, VendorId = vendorId, ModelType = gpuModel };
                this.Database.Models.Add(model);
            }

            for (int i = 0; i < quaterCount; i++)
            {
                var vendorId = vendorIds[RandomGenerator.Instance.GetRandomNumber(0, vendorIds.Count - 1)];
                var name = RandomGenerator.Instance.GetRandomString(15);
                var model = new Model() { Name = name, VendorId = vendorId, ModelType = sdModel };
                this.Database.Models.Add(model);
            }

            this.Database.SaveChanges();
        }
    }
}
