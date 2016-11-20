using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddingSampleData.Importers
{
    public class ModelTypesImporter : Importer
    {
        public ModelTypesImporter(ComputersDbEntities db)
            : base(db)
        {
        }

        public override void Import(int count)
        {
            var modelType1 = new ModelType() { Type = "Computer" };
            var modelType2 = new ModelType() { Type = "CPU" };
            var modelType3 = new ModelType() { Type = "GPU" };
            var modelType4 = new ModelType() { Type = "Storage Device" };

            this.Database.ModelTypes.Add(modelType1);
            this.Database.ModelTypes.Add(modelType2);
            this.Database.ModelTypes.Add(modelType3);
            this.Database.ModelTypes.Add(modelType4);

            this.Database.SaveChanges();
        }

        
    }
}
