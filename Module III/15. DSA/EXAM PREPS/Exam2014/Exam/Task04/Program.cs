using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            long[] dis = new long[n];

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split();
                dis[i] = long.Parse(line[0]);
            }

            long[] left = new long[n];
            long[] right = new long[n];
            
            left = FindLongestIncreasingSubsequence(dis, false);
            //Console.WriteLine(string.Join(" ", left));

            right = FindLongestDecreasingSubsequence(dis, true);
            //Console.WriteLine(string.Join(" ", right));
            long max = 0;
            for (int i = 0; i < n; i++)
            {
                if(left[i] + right[i] > max)
                {
                    max = left[i] + right[i] - 1;
                }
            }

            Console.WriteLine(max);
        }

        public static long[] FindLongestIncreasingSubsequence(long[] sequence, bool isReversed)
        {
            int n = sequence.Length;
            long[] arr = new long[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = 1;
            }


            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if(sequence[j] < sequence[i])
                    {
                        if(arr[i] < arr[j] + 1)
                        {
                            arr[i] = arr[j] + 1;
                        }
                        
                    }
                }
            }

            return arr;
        }

        public static long[] FindLongestDecreasingSubsequence(long[] sequence, bool isReversed)
        {
            int n = sequence.Length;
            long[] arr = new long[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = 1;
            }


            for (int i = n - 2; i >= 0; i--)
            {
                for (int j = n - 1; j > i; j--)
                {
                    if (sequence[j] < sequence[i])
                    {
                        if (arr[i] < arr[j] + 1)
                        {
                            arr[i] = arr[j] + 1;
                        }

                    }
                }
            }

            return arr;
        }
    }
}
