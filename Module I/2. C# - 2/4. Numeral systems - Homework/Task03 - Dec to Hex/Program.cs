using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        ulong dec = ulong.Parse(Console.ReadLine());
        List<string> hexResult = new List<string>();
        if (dec == 0)
        {
            Console.WriteLine(0);
            return;   
        }

        while (dec > 0)
        {
            string currentHex = string.Empty;
            if (dec % 16 < 10)
            {
                currentHex = (dec % 16).ToString();
                hexResult.Add(currentHex);
            }
            else
            {
                switch (dec % 16)
                {
                    case 10: currentHex = "A"; break;
                    case 11: currentHex = "B"; break;
                    case 12: currentHex = "C"; break;
                    case 13: currentHex = "D"; break;
                    case 14: currentHex = "E"; break;
                    case 15: currentHex = "F"; break;
                }

                hexResult.Add(currentHex);
            }

            dec /= 16;
        }

        hexResult.Reverse();

        Console.WriteLine(string.Join("", hexResult));

    }
}

