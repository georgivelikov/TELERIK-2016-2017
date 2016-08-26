using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        string input = Console.ReadLine();
        long result = 0;
        int pow = 0;
        for (int i = input.Length - 1; i >= 0; i--)
        {
            if (input[i] >= 48 && input[i] <= 57)
            {
                int current = int.Parse(input[i].ToString());
                result += (long)Math.Pow(16, pow) * current;
            }
            else
            {
                switch (input[i])
                {
                    case 'A':
                        result += (long)Math.Pow(16, pow) * 10;
                        break;
                    case 'B':
                        result += (long)Math.Pow(16, pow) * 11;
                        break;
                    case 'C':
                        result += (long)Math.Pow(16, pow) * 12;
                        break;
                    case 'D':
                        result += (long)Math.Pow(16, pow) * 13;
                        break;
                    case 'E':
                        result += (long)Math.Pow(16, pow) * 14;
                        break;
                    case 'F':
                        result += (long)Math.Pow(16, pow) * 15;
                        break;
                }
            }

            pow++;
        }

        Console.WriteLine(result);
    }
}

