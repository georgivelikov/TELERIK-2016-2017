using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
    public static void Main()
    {
        int[] code = Console.ReadLine().Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
        int n = int.Parse(Console.ReadLine());

        Dictionary<int, char> map = new Dictionary<int, char>();
        Dictionary<string, int> decode = new Dictionary<string, int>();
        for (int i = 0; i < n; i++)
        {
            string helper = string.Empty;
            string inputLine = Console.ReadLine();
            for (int j = 1; j < inputLine.Length; j++)
            {
                helper += inputLine[j];
            }

            int count = int.Parse(helper);
            map.Add(count, inputLine[0]);
            string str = new string('1', count);
            decode.Add(str, count);

        }

        List<char> list = new List<char>();
        for (int i = 0; i < code.Length; i++)
        {
            list.AddRange(Convert.ToString(code[i], 2).PadLeft(8, '0').ToCharArray());
        }

        while (list[list.Count - 1] == '0')
        {
            list.RemoveAt(list.Count - 1);
        }

        string line = new string(list.ToArray());

        string[] arr = line.Split('0');

        StringBuilder result = new StringBuilder();
        for (int i = 0; i < arr.Length; i++)
        {
            string current = arr[i];
            result.Append(map[decode[current]]);
        }

        Console.WriteLine(result);
    }
}

