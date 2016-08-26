using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

        Console.WriteLine(CountLarger(arr));
    }

    private static int CountLarger(int[] arr)
    {
        int counter = 0;
        for (int i = 1; i < arr.Length - 1; i++)
        {
            if (arr[i] > arr[i - 1] && arr[i] > arr[i + 1])
            {
                counter++;
            }
        }

        return counter;
    }
}

