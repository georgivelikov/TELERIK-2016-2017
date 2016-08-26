using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] arrOne = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
        int[] arrTwo = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
        int[] result = new int[n];
        for (int i = 0; i < n; i++)
        {
            result[i] = arrOne[i] + arrTwo[i];
        }

        Console.WriteLine(string.Join(" ", result));
    }
}

