using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task08___Maximal_Sum
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            //int n = 10;
            //int[] arr = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };
            //LinkedList<int> list = new LinkedList<int>();

            int currentSum = 0;
            int maxSum = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                currentSum = 0;
                for (int j = i; j < n; j++)
                {
                    currentSum += arr[j];
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                    }
                }
            }

            Console.WriteLine(maxSum);
        }
    }
}
