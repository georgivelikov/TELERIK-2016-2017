using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

        long oddProduct = 1;
        long evenProduct = 1;

        for (int i = 0; i < n; i++)
        {
            if (i % 2 == 0)
            {
                oddProduct *= arr[i];
            }
            else
            {
                evenProduct *= arr[i];
            }
        }

        if (oddProduct == evenProduct)
        {
            Console.WriteLine("yes {0}", oddProduct);
        }
        else
        {
            Console.WriteLine("no {0} {1}", oddProduct, evenProduct);
        }
    }
}

