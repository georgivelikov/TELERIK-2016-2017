using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03___Compare_char_arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] first = Console.ReadLine().ToCharArray();
            char[] second = Console.ReadLine().ToCharArray();

            int len = Math.Min(first.Length, second.Length);

            for (int i = 0; i < len; i++)
            {
                if (first[i].ToString().CompareTo(second[i].ToString()) > 0)
                {
                    Console.WriteLine(">");
                    return;
                }
                else if (first[i].ToString().CompareTo(second[i].ToString()) < 0)
                {
                    Console.WriteLine("<");
                    return;
                }
            }

            if (first.Length > second.Length)
            {
                Console.WriteLine(">");
            }
            else if (first.Length < second.Length)
            {
                Console.WriteLine("<");
            }
            else
            {
                Console.WriteLine("=");
            }
        }
    }
}
