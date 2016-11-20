using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Company.DataGenerator;

namespace AddingSampleData.Importers
{
    public class VendorImporter : Importer
    {
        public VendorImporter(ComputersDbEntities db)
            : base(db)
        {
        }

        public override void Import(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var name = RandomGenerator.Instance.GetRandomString(15);

                var newVendor = new Vendor() { Name = name };
                this.Database.Vendors.Add(newVendor);
            }

            this.Database.SaveChanges();
        }
    }
}
