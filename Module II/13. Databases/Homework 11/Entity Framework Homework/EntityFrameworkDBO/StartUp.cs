using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDBO
{
    public class StartUp
    {
        public static void Main()
        {
            DAO.AddCustomer(
                "PSIVN", 
                "Bulgarian Company", 
                "Pesho Ivanov", 
                "Lord", 
                "Some address", 
                "Slatina","Sofiiski", 
                "2000", 
                "Bulgaria", 
                "666-666", 
                "555-555");
        }
    }
}
