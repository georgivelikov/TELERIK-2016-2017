namespace Task01
{
    using System;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            StringBuilder sb = new StringBuilder("Test_string");

            var result = sb.Substring(0, 4);
            Console.WriteLine(result);

            var result1 = sb.Substring(3, 8);
            Console.WriteLine(result1);

            // var result2 = sb.Substring(3, 9); // throws Error as expected
            // Console.WriteLine(result2);
        }
    }
}
