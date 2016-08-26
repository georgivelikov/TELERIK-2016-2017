using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = Console.ReadLine().Split().Select(p => int.Parse(p)).ToArray();
        int x = int.Parse(Console.ReadLine());

        Console.WriteLine(CountAppearance(arr, x));
    }

    private static int CountAppearance(int[] arr, int x)
    {
        int counter = 0;

        foreach (var num in arr)
        {
            if (num == x)
            {
                counter++;
            }
        }

        return counter;
    }
}

