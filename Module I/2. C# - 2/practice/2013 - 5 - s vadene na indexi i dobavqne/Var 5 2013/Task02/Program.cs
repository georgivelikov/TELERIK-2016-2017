using System;
using System.Linq;
using System.Text;

using Wintellect.PowerCollections;

public class Program
{
    public static void Main()
    {
        string[] input = Console.ReadLine().Split();
        StringBuilder sb = new StringBuilder();
        int counter = 0;
        bool wordStillExist = true;

        while (wordStillExist)
        {
            wordStillExist = false;
            StringBuilder current = new StringBuilder();
            for (int j = 0; j < input.Length; j++)
            {

                if (input[j].Length - 1 - counter >= 0)
                {
                    wordStillExist = true;
                    current.Append(input[j][input[j].Length - 1 - counter]);
                }
            }

            sb.Append(current);
            counter++;
        }

        BigList<char> arr = new BigList<char>(sb.ToString().ToCharArray().ToList());
        int len = arr.Count;
        for (int i = 0; i < arr.Count; i++)
        {
            char c = arr[i];
            int index = 0;
            if (Char.IsLower(c))
            {
                index = c - 96;
            }
            else if (Char.IsUpper(c))
            {
                index = c - 64;
            }


            int target = (i + index) % arr.Count;
            if (target == i)
            {
                continue;
            }

            if (target < i)
            {
                arr.Insert(target, c);
                arr.RemoveAt(i + 1);
            }
            else if(target > i)
            {
                arr.Insert(target + 1, c);
                arr.RemoveAt(i);
            }
        }

        Console.WriteLine(string.Join(string.Empty, arr));
    }
}
