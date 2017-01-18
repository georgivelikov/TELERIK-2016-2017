using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task08
{
    public class Program
    {
        private static List<List<long>> pascal = new List<List<long>>();

        public static void Main()
        {
            
            string input = Console.ReadLine();
            string x = Console.ReadLine();
            var a = input[1];
            var b = input[3];
            int n = int.Parse(Console.ReadLine());
            
            BuildPascalTriangle(n);

            var coefs = pascal[n];

            var powerA = n;
            var powerB = 0;

            var result = new List<string>();

            for (int i = 0; i < coefs.Count; i++)
            {
                var coef = coefs[i];
                var current = new StringBuilder();

                if (coef != 1)
                {
                    current.Append(coef);
                }
                if (powerA != 0)
                {
                    current.Append(string.Format("({0}^{1})", a, powerA));
                }
                if (powerB != 0)
                {
                    current.Append(string.Format("({0}^{1})", b, powerB));
                }

                result.Add(current.ToString());

                powerA--;
                powerB++;
            }

            Console.WriteLine(string.Join("+", result));
        }

        private static void BuildPascalTriangle(long n)
        {
            pascal.Add(new List<long>() { 1 });
            pascal.Add(new List<long>() { 1, 1 });
            for (int i = 2; i <= n; i++)
            {
                var list = new List<long>();
                list.Add(1);
                for (int j = 1; j < i; j++)
                {
                    list.Add(pascal[i - 1][j - 1] + pascal[i - 1][j]);
                }

                list.Add(1);

                pascal.Add(list);
            }
        }
    }
}
