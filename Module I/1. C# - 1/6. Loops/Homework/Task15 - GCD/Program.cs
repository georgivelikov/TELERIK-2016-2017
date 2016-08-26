using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
       long[] input = Console.ReadLine().Split().Select(x => long.Parse(x)).ToArray();
       long a = input[0];
       long b = input[1];
       long counter = 1;
       long result;
        while (true)
        {
            result = a * counter;
            if (result % b == 0)
            {
                break;
            }

            counter++;
        }

        long lcm = result;

        long gcd = Math.Abs((a * b) / lcm);
        Console.WriteLine(gcd);
    }
}

