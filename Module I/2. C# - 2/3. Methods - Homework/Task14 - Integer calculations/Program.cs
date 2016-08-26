using System;
using System.Linq;
using System.Numerics;

public class Program
{
    public static void Main()
    {
        double[] arr = Console.ReadLine().Split().Select(x => double.Parse(x)).ToArray();
        Console.WriteLine(Minimum(arr));
        Console.WriteLine(Maximum(arr));
        Console.WriteLine("{0:0.00}", Average(arr));
        Console.WriteLine(Sum(arr));
        Console.WriteLine(Product(arr));
    }

    private static double Sum(double[] arr)
    {
        double sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }

        return sum;
    }

    private static double Minimum(double[] arr)
    {
        double min = double.MaxValue;

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] < min)
            {
                min = arr[i];
            }
        }

        return min;
    }

    private static double Maximum(double[] arr)
    {
        double max = double.MinValue;

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
            }
        }

        return max;
    }

    private static double Average(double[] arr)
    {
        return Math.Round(Sum(arr) / arr.Length, 2);
    }

    private static BigInteger Product(double[] arr)
    {
        BigInteger product = 1;
        for (int i = 0; i < arr.Length; i++)
        {
            product *= (BigInteger)arr[i];
        }

        return product;
    }
}
