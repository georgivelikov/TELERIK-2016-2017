using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task03
{
    public class Program
    {
        public static void Main()
        {
            string input = "This is the TEXT. Text, text, text – THIS TEXT! Is this the text?";
            input = input.ToLower();

            var pattern = "\\w+";

            var regex = new Regex(pattern);

            var matches = regex.Matches(input);

            var map = new SortedDictionary<string, int>();

            foreach (var item in matches)
            {
                if (!map.ContainsKey(item.ToString()))
                {
                    map.Add(item.ToString(), 0);
                }

                map[item.ToString()]++;
            }

            var sortedByValue = map.OrderBy(x => x.Value);

            foreach (var item in sortedByValue)
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }
        }
    }
}
