using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static int[] elements;
    private static bool[] used;
    private static int sum = 0;

    public static void Main()
    {
        int t = int.Parse(Console.ReadLine());
        while (t > 0)
        {
            int[] nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = nk[0];
            int k = nk[1];

            elements = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] arr = new int[k];
            used = new bool[elements.Length + 1];
            GenerateCombinations(arr);
            Console.WriteLine(sum);
            sum = 0;
            t--;
        }

        
    }

    private static void GenerateCombinations(int[] arr, int index = 0, int start = 0)
    {
        if (index >= arr.Length)
        {
            var res = arr.Select(i => elements[i]);
            var currentSum = res.Sum();
            PrintCombinations(arr, currentSum);
            sum += currentSum;
        }
        else
        {
            for (int i = start; i < elements.Length; i++)
            {
                arr[index] = i;
                GenerateCombinations(arr, index + 1, i + 1);
            }
        }
    }

    //private static void GenerateUniqueCombinations(int[] arr, int index = 0, int start = 0)
    //{
    //    if (index >= arr.Length)
    //    {
    //        PrintCombinations(arr);
    //    }
    //    else
    //    {
    //        var unique = new HashSet<int>();
    //        for (int i = start; i < elements.Length; i++)
    //        {
    //            if (!unique.Contains(elements[i]))
    //            {
    //                arr[index] = i;
    //                GenerateUniqueCombinations(arr, index + 1, i + 1);

    //                unique.Add(elements[i]);
    //            }
    //        }
    //    }
    //}

    private static void PrintCombinations(int[] arr, int arrSum)
    {
        Console.WriteLine("{0} -> {1}", string.Join(", ", arr.Select(i => elements[i])), arrSum);
    }
}


