using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImport.Importers
{
    public interface IImporter
    {
        void Import(int count);
    }
}
