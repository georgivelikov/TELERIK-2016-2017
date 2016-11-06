using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            // I have no clue here, sorry
            var childEmpl = new ChildEmployee();
            var x = childEmpl.Territories.Schema;
            Console.WriteLine(x);

        }
    }
}
