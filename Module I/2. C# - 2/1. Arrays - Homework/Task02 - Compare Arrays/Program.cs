using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02___Compare_Arrays
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                int current = int.Parse(Console.ReadLine());
                array[i] = current;
            }

            for (int i = 0; i < n; i++)
            {
                int current = int.Parse(Console.ReadLine());
                if (array[i] != current)
                {
                    Console.WriteLine("Not equal");
                    return;
                }
            }

            Console.WriteLine("Equal");
        }
    }
}
