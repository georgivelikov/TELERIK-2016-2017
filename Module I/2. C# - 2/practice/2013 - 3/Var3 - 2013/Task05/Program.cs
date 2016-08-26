using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class Program
{
    private static int winIndex = -1;
    private static int bites = 0;
    private static int counter = 0;

    public static void Main()
    {
        int[] arrOne =
            Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();
        int[] arrTwo =
            Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();
        int f = int.Parse(Console.ReadLine());
        int[] arrThree =
            Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

        SolveOne(arrOne);
        Console.WriteLine(winIndex);
        SolveTwo(arrTwo, f);
        Console.WriteLine(bites);
    }

    public static void SolveOne(int[] arr)
    {
        var results = arr.Where(x => x <= 21).ToList();
        results.Sort();

        if (results.Count == 1)
        {
            winIndex = Array.IndexOf(arr, results[0]);
        }
        else
        {
            if (results[results.Count - 1] != results[results.Count - 2])
            {
                winIndex = Array.IndexOf(arr, results[results.Count - 1]);
            }
        }
    }

    public static void SolveTwo(int[] arr, int f)
    {
        f++;
        Array.Sort(arr);
        List<int> list = new List<int>(arr);

        for (int i = arr.Length - 1; i >= 0; i -= f)
        {
            bites += arr[i];
        }
    }

    public static void SolveThree(int[] arr)
    {
        int g1 = arr[0];
        int s1 = arr[1];
        int b1 = arr[2];
        int g2 = arr[3];
        int s2 = arr[4];
        int b2 = arr[5];

        int[] coins = new int[3];

        coins[0] = g1 - g2;
        coins[1] = s1 - s2;
        coins[2] = b1 - b2;

        while (coins[0] < 0)
        {
            if
        }
    }
}

