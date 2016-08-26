using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
    public static void Main()
    {
        int[] arr = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
        List<double> sums = new List<double>();
        int currentIndex = 0;

        while (true)
        {
            string line = Console.ReadLine();
            if (line == "stop")
            {
                break;
            }

            string[] input = line.Split();
            int times = int.Parse(input[0]);
            int step = int.Parse(input[2]);
            string dir = input[1];
            double currentSum = 0;

            if (dir == "right")
            {
                for (int i = 0; i < times; i++)
                {
                    currentIndex = (currentIndex + step) % arr.Length;
                    currentSum += arr[currentIndex];
                }
            }
            else
            {
                for (int i = 0; i < times; i++)
                {
                    if (currentIndex - (step % arr.Length) >= 0)
                    {
                        currentIndex -= step % arr.Length;
                        currentSum += arr[currentIndex];
                    }
                    else
                    {
                        currentIndex = arr.Length + currentIndex - (step % arr.Length);
                        currentSum += arr[currentIndex];
                    }              
                }
            }

            sums.Add(currentSum);
        }


        Console.WriteLine("{0:0.0}", sums.Average());
    }
}

