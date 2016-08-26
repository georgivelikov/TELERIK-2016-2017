using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task07___Selection_Sort
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            //int n = 6;
            //int[] arr = { 3, 4, 1, 5, 2, 6 };
            int minIndex = 0;
            int currentMin = int.MaxValue;
            int start = 0;

            while (true)
            {
                for (int i = start; i < n; i++)
                {
                    if (arr[i] < currentMin)
                    {
                        minIndex = i;
                        currentMin = arr[i];
                    }
                }

                int current = arr[start];
                arr[start] = arr[minIndex];
                arr[minIndex] = current;
                start++;
                currentMin = int.MaxValue;

                if (start == n)
                {
                    break;
                }
            }
            

            Console.WriteLine(string.Join("\n", arr));
        }
    }
}
