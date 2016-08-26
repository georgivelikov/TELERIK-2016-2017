using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                long[] arr = Console.ReadLine().Split().Select(x => long.Parse(x)).ToArray();

                List<long> seq = new List<long>();
                long previousValue = long.MinValue;
                bool isSequanceIncreasing = true;
                bool isAbsoluteDiff = true;

                for (int j = 1; j < arr.Length; j++)
                {
                    long value = Math.Abs(arr[j] - arr[j - 1]);
                    if (value >= previousValue)
                    {
                        seq.Add(value);
                        previousValue = value;
                    }
                    else
                    {
                        isSequanceIncreasing = false;
                        break;
                    }
                }

                if (isSequanceIncreasing)
                {
                    for (int j = 1; j < seq.Count; j++)
                    {
                        long value = seq[j] - seq[j - 1];
                        if (value != 1 && value != 0)
                        {
                            isAbsoluteDiff = false;
                            Console.WriteLine("False");
                        }
                    }

                    if (isAbsoluteDiff)
                    {
                        Console.WriteLine("True");
                    }
                }
                else
                {
                    Console.WriteLine("False");
                }
            }
        }
    }
}