using System;
using System.Collections.Generic;

namespace Task18___Remove_Elements
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

            List<int> list = new List<int>();

            for (int i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    list.Add(arr[i]);
                    continue;
                }

                if (list[list.Count - 1] <= arr[i])
                {
                    list.Add(arr[i]);
                }
                else
                {
                    for (int j = 0; j < list.Count; j++)
                    {
                        if (list[j] > arr[i])
                        {
                            list[j] = arr[i];
                            break;
                        }
                    }
                }
                
                list.Sort();
            }

            // To make things simpler, we can keep in the array S, not the actual integers, 
            // but their indices(positions) in the set. We do not keep {1, 2, 4, 5, 8}, but keep {4, 5, 3, 7, 8}.
            // check http://stackoverflow.com/questions/2631726/how-to-determine-the-longest-increasing-subsequence-using-dynamic-programming
            // list is not the LIS, but list.Count is equal to the count of the LIS
            Console.WriteLine(arr.Length - list.Count);
        }
    }
}
