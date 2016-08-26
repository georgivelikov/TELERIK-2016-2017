using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        string input = Console.ReadLine();

        int one = 0;
        int two = 0;

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '(')
            {
                one++;
            }
            if (input[i] == ')')
            {
                two++;
            }
        }

        if (one == two)
        {
            Console.WriteLine("Correct");
        }
        else
        {
            Console.WriteLine("Incorrect");
        }
    }
}

