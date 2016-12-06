using System;
using System.Linq;

namespace Task01_Exchange_Rates
{
    public class Program
    {
        public static void Main()
        {
            var c = decimal.Parse(Console.ReadLine());
            var n = int.Parse(Console.ReadLine());
            var arr1 = new decimal[n];
            var arr2 = new decimal[n];

            for (int i = 0; i < n; i++)
            {
                var currentRate = Console.ReadLine().Split(' ').Select(x => decimal.Parse(x)).ToArray();
                arr1[i] = currentRate[0];
                arr2[i] = currentRate[1];
            }

            decimal sum1 = c;
            decimal sum2 = c * arr1[0];

            for (int i = 1; i < n; i++)
            {
                var current1 = sum2 * arr2[i];
                var current2 = sum1 * arr1[i];

                if (sum1 < current1)
                {
                    sum1 = current1;
                }

                if (sum2 < current2)
                {
                    sum2 = current2;
                }
            }

            Console.WriteLine("{0:0.00}", sum1);
        }
    }
}
