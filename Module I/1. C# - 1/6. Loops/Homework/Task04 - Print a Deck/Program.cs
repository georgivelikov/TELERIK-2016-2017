using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        string input = Console.ReadLine();
        int limit = 0;
        Dictionary<int, string> dic = new Dictionary<int, string>();
        dic.Add(2, "2");
        dic.Add(3, "3");
        dic.Add(4, "4");
        dic.Add(5, "5");
        dic.Add(6, "6");
        dic.Add(7, "7");
        dic.Add(8, "8");
        dic.Add(9, "9");
        dic.Add(10, "10");
        dic.Add(11, "J");
        dic.Add(12, "Q");
        dic.Add(13, "K");
        dic.Add(14, "A");
        try
        {
            limit = int.Parse(input);
        }
        catch (Exception)
        {
            if (input == "J")
            {
                limit = 11;
            }

            if (input == "Q")
            {
                limit = 12;
            }

            if (input == "K")
            {
                limit = 13;
            }

            if (input == "A")
            {
                limit = 14;
            }
        }

        for (int i = 2; i <= limit; i++)
        {
            Console.WriteLine("{0} of spades, {0} of clubs, {0} of hearts, {0} of diamonds", dic[i]);
        }
    }
}

