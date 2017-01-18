using System;
using System.Linq;

using Wintellect.PowerCollections;

public class Program
{
    public static void Main()
    {
        var products = new OrderedBag<Product>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            var product = new Product(input[0], decimal.Parse(input[1]));
            products.Add(product);
        }

        decimal[] range = Console.ReadLine().Split().Select(x => decimal.Parse(x)).ToArray();

        var productsInRange = products.Range(new Product("", range[0]), true, new Product("", range[1]), true);

        foreach (var pr in productsInRange)
        {
            Console.WriteLine(pr);
        }
    }
}