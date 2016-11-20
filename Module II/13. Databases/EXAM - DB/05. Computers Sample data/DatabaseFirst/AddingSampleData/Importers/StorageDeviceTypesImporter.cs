using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddingSampleData.Importers
{
    public class StorageDeviceTypesImporter : Importer
    {
        public StorageDeviceTypesImporter(ComputersDbEntities db)
            : base(db)
        {
        }

        public override void Import(int count)
        {
            var sdType1 = new StorageDeviceType() { Type = "SSD" };
            var sdType2 = new StorageDeviceType() { Type = "HDD" };

            this.Database.StorageDeviceTypes.Add(sdType1);
            this.Database.StorageDeviceTypes.Add(sdType2);

            this.Database.SaveChanges();
        }
    }
}
