using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

        Array.Sort(arr);

        Console.WriteLine(string.Join(" ", arr));
    }
}

