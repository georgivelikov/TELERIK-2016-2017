namespace Task02
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class Program
    {
        public static void Main()
        {
            IEnumerable<double> list = new Collection<double> { 1, 2, 3, 4, 5 }; // does not work for decimals

            var sum = list.CustomSum();
            Console.WriteLine("sum: " + sum);

            var product = list.CustomProduct();
            Console.WriteLine("product: " + product);

            var max = list.CustomMax();
            Console.WriteLine("max: " + max);

            var min = list.CustomMin();
            Console.WriteLine("min: " + min);

            var avg = list.CustomAverage();
            Console.WriteLine("avg: " + avg);

        }
    }
}
