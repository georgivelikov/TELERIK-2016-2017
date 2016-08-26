using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        double[] arr = new double[n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = double.Parse(Console.ReadLine());
        }

        Console.WriteLine("min={0:f2}", arr.Min());
        Console.WriteLine("max={0:f2}", arr.Max());
        Console.WriteLine("sum={0:f2}", arr.Sum());
        Console.WriteLine("avg={0:f2}", arr.Average());
    }
}

