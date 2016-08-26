using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        SortedDictionary<int, string> map = new SortedDictionary<int, string>();
        string word = Console.ReadLine();
        int n = int.Parse(Console.ReadLine());
        string[] punctuation = { ",", ".", "(", ")", ";", "-", "!", "?" };

        for (int i = 0; i < n; i++)
        {
            int counter = 0;
            int index = 0;
            string line = Console.ReadLine();
            string pattern = @"\b" + word + @"\b";

            Regex reg = new Regex(pattern, RegexOptions.IgnoreCase);
            var matches = reg.Matches(line);

            counter = matches.Count;
            map.Add(counter, line);

        }

        var sortedMap = map.OrderByDescending(x => x.Key);

        foreach (var item in sortedMap)
        {
            string result = item.Value;
            string repl = @"\b" + word + @"\b";
            result = Regex.Replace(result, repl, word.ToUpper(), RegexOptions.IgnoreCase);
            
            //result = Regex.Replace(result, @"[,.\(\);\-!?]+", string.Empty);
            result = Regex.Replace(result, @"[,.\(\);\-!?]+", " ");
            result = Regex.Replace(result, @"\s+", " ");
            Console.WriteLine(result);
        }

    }
}

