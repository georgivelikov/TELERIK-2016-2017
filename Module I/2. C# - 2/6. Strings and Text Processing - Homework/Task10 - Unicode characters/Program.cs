using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10___Unicode_characters
{
    using System.Globalization;

    public class Program
    {

        public static void Main()
        {
            string line = Console.ReadLine();
            line = line.Replace("\\n", String.Empty);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < line.Length; i++)
            {
                sb.Append("\\u" + ((int)line[i]).ToString("X").PadLeft(4, '0'));
            }
            
            Console.WriteLine(sb.ToString());

        }
    }
}
