using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static string[] objects;

    public static void Main()
    {
        objects = new[] { "1", "2", "3" };

        // int n = objects.Length;
        int k = 2; // pick k out of n objects, k < n, order matters, reps allowed
        
        int[] arr = new int[k];

        GenerateVariations(arr);
    }

    private static void GenerateVariations(int[] arr, int index = 0)
    {
        if (index >= arr.Length)
        {
            PrintVariations(arr);
        }
        else
        {
            for (int i = 0; i < objects.Length; i++)
            {
                arr[index] = i;
                GenerateVariations(arr, index + 1);
            }
        }
    }

    private static void GenerateUniqueVariations(int[] arr, int index = 0)
    {
        if (index >= arr.Length)
        {
            PrintVariations(arr);
        }
        else
        {
            var unique = new HashSet<string>();
            for (int i = 0; i < objects.Length; i++)
            {
                if (!unique.Contains(objects[i]))
                {
                    arr[index] = i;
                    GenerateUniqueVariations(arr, index + 1);
                    unique.Add(objects[i]);
                }
            }
        }
    }

    private static void PrintVariations(int[] arr)
    {
        Console.WriteLine("{0}", string.Join(", ", arr.Select(i => objects[i])));
    }
}


