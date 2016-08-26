using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12___Index_of_letters
{
    class Program
    {
        static void Main()
        {
            char[] arr = Console.ReadLine().ToLower().ToCharArray();

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i] - 97);
            }
            
        }
    }
}
