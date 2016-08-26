using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task09___Frequent_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            int maxElement = int.MinValue;
            int maxCount = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                int currentCount = 0;
                int currentElement = arr[i];

                for (int j = i; j < n; j++)
                {
                    if (arr[j] == currentElement)
                    {
                        currentCount++;
                    }
                }

                if (currentCount > maxCount)
                {
                    maxCount = currentCount;
                    maxElement = currentElement;
                }
            }

            Console.WriteLine("{0} ({1} times)", maxElement, maxCount);
        }
    }
}
