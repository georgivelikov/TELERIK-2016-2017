using System;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        string input = Console.ReadLine();
        int lenOne = 8;
        int lenTwo = 9;
        int prevFindFirstIndex = 0;
        int prevFindSecIndex = 0;

        while (true)
        {
            int firstIndex = input.IndexOf(@"<upcase>", prevFindFirstIndex);
            if (firstIndex < 0)
            {
                break;
            }

            int secondIndex = input.IndexOf(@"</upcase>", prevFindSecIndex);
            if (secondIndex < 0)
            {
                break;
            }

            prevFindFirstIndex = firstIndex + 1;
            prevFindSecIndex = secondIndex + 1;
            int startIndex = firstIndex;
            int lenOfReplacement = secondIndex + lenTwo - startIndex;
            string subText = input.Substring(startIndex, lenOfReplacement);
            string replacement = subText.ToUpper();
            input = input.Replace(subText, replacement);
        }

        input = input.Replace(@"<UPCASE>", string.Empty);
        input = input.Replace(@"</UPCASE>", string.Empty);
        Console.WriteLine(input);
    }
}

