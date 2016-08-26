namespace Task06
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var list = new List<int>() { 1, 3, 5, 7, 14, 21, 25, 33, 35, 46, 63, 105 };

            var result = list.Where(n => n % 3 == 0 && n % 7 == 0);

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
