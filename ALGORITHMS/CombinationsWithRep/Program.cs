using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static string[] objects;

    public static void Main()
    {
        objects = new[] { "1", "2", "3" };
        int n = objects.Length;
        int k = 2; // pick k out of n objects, k < n, order does not matter, reps allowed

        int[] arr = new int[k];

        GenerateCombinations(arr);
    }

    private static void GenerateCombinations(int[] arr, int index = 0, int start = 0)
    {
        if (index >= arr.Length)
        {
            PrintCombinations(arr);
        }
        else
        {
            for (int i = start; i < objects.Length; i++)
            {
                arr[index] = i;
                GenerateCombinations(arr, index + 1, i);
            }
        }
    }

    private static void GenerateUniqueCombinations(int[] arr, int index = 0, int start = 0)
    {
        if (index >= arr.Length)
        {
            PrintCombinations(arr);
        }
        else
        {
            var unique = new HashSet<string>();
            for (int i = start; i < objects.Length; i++)
            {
                if (!unique.Contains(objects[i]))
                {
                    arr[index] = i;
                    GenerateUniqueCombinations(arr, index + 1, i);
                    unique.Add(objects[i]);
                }
               
            }
        }
    }

    private static void PrintCombinations(int[] arr)
    {
        Console.WriteLine("{0}", string.Join(", ", arr.Select(i => objects[i])));
    }
}


