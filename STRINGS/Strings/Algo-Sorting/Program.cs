using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo_Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            string useless = Console.ReadLine();

            int[] charNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] charCounts = new int[256];

            for (int i = 0; i < charNumbers.Length; i++)
            {
                var current = charNumbers[i];

                charCounts[current]++;
            }
            charCounts['x'] = 0;
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < charCounts['A' + i]; j++)
                {
                    result.Append((char)('A' + i));
                }

                for (int j = 0; j < charCounts['a' + i]; j++)
                {
                    result.Append((char)('a' + i));
                }
            }

            for (int i = 1; i < 10; i++)
            {
                for (int j = 0; j < charCounts['0' + i]; j++)
                {
                    result.Append((char)('0' + i));
                }
            }

            for (int i = 0; i < charCounts['0']; i++)
            {
                result.Append((char)'0');
            }

            Console.WriteLine(result.ToString());
        }
    }
}
