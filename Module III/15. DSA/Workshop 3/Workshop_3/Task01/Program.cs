using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            long result = 0;
            for (int i = 0; i < n; i++)
            {
                long num = long.Parse(Console.ReadLine());

                result ^= num;
            }

            Console.WriteLine(result);
        }
    }
}
