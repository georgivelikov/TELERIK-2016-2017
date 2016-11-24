using System;
using System.Linq;

public class Program
{
    private static string[] objects;

    public static void Main()
    {
        objects = new[] { "test", "rock", "fun" };
        int n = objects.Length;
        int k = 2;

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
                GenerateCombinations(arr, index + 1, i + 1);
            }
        }
    }

    private static void PrintCombinations(int[] arr)
    {
        Console.WriteLine("{0}", string.Join(", ", arr.Select(i => objects[i])));
    }
}


