using System;
using System.Numerics;

public class Program
{
    public static void Main()
    {
        string hex = Console.ReadLine();
        BigInteger decResult = 0;                  
        for (int i = hex.Length - 1; i >= 0; i--)
        {
            switch (hex[i])
            {
                case '0': decResult += 0 * BigInteger.Pow(16, hex.Length - 1 - i); break; // remember BigInteger.Pow()
                case '1': decResult += 1 * BigInteger.Pow(16, hex.Length - 1 - i); break;
                case '2': decResult += 2 * BigInteger.Pow(16, hex.Length - 1 - i); break;
                case '3': decResult += 3 * BigInteger.Pow(16, hex.Length - 1 - i); break;
                case '4': decResult += 4 * BigInteger.Pow(16, hex.Length - 1 - i); break;
                case '5': decResult += 5 * BigInteger.Pow(16, hex.Length - 1 - i); break;
                case '6': decResult += 6 * BigInteger.Pow(16, hex.Length - 1 - i); break;
                case '7': decResult += 7 * BigInteger.Pow(16, hex.Length - 1 - i); break;
                case '8': decResult += 8 * BigInteger.Pow(16, hex.Length - 1 - i); break;
                case '9': decResult += 9 * BigInteger.Pow(16, hex.Length - 1 - i); break;
                case 'A': decResult += 10 * BigInteger.Pow(16, hex.Length - 1 - i); break;
                case 'B': decResult += 11 * BigInteger.Pow(16, hex.Length - 1 - i); break;
                case 'C': decResult += 12 * BigInteger.Pow(16, hex.Length - 1 - i); break;
                case 'D': decResult += 13 * BigInteger.Pow(16, hex.Length - 1 - i); break;
                case 'E': decResult += 14 * BigInteger.Pow(16, hex.Length - 1 - i); break;
                case 'F': decResult += 15 * BigInteger.Pow(16, hex.Length - 1 - i); break;
            }
        }

        Console.WriteLine(decResult);
    }
}

