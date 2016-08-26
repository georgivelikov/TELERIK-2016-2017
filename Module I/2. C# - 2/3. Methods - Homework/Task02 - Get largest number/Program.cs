using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int[] input = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

        Console.WriteLine(GetMax(input[0], GetMax(input[1], input[2])));
    }

    private static int GetMax(int a, int b)
    {
        if (a >= b)
        {
            return a;
        }
        else
        {
            return b;
        }
    }
}

