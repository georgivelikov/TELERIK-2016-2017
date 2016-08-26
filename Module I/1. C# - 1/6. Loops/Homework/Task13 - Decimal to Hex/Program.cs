using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        LinkedList<char> result = new LinkedList<char>();
        long n = long.Parse(Console.ReadLine());

        while (n > 0)
        {
            if (n % 16 < 10)
            {
                char currentChar = (char)(48 + n % 16);
                result.AddFirst(currentChar);
            }
            else
            {
                switch (n % 16)
                {
                    case 10:
                        result.AddFirst('A');
                        break;
                    case 11:
                        result.AddFirst('B');
                        break;
                    case 12:
                        result.AddFirst('C');
                        break;
                    case 13:
                        result.AddFirst('D');
                        break;
                    case 14:
                        result.AddFirst('E');
                        break;
                    case 15:
                        result.AddFirst('F');
                        break;
                }
            }

            n /= 16;
        }

        Console.WriteLine(string.Join("", result));
    }
}
