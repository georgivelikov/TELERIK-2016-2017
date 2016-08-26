using System;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        string hex = Console.ReadLine();
        string binResult = string.Empty;
        for (int i = 0; i < hex.Length; i++)
        {
            switch (hex[i])
            {
                case '0': binResult += "0000"; break;
                case '1': binResult += "0001"; break;
                case '2': binResult += "0010"; break;
                case '3': binResult += "0011"; break;
                case '4': binResult += "0100"; break;
                case '5': binResult += "0101"; break;
                case '6': binResult += "0110"; break;
                case '7': binResult += "0111"; break;
                case '8': binResult += "1000"; break;
                case '9': binResult += "1001"; break;
                case 'A': binResult += "1010"; break;
                case 'B': binResult += "1011"; break;
                case 'C': binResult += "1100"; break;
                case 'D': binResult += "1101"; break;
                case 'E': binResult += "1110"; break;
                case 'F': binResult += "1111"; break;
            }
        }

        string pattern = "^0+";
        Regex regex = new Regex(pattern);
        binResult = regex.Replace(binResult, string.Empty);

        Console.WriteLine(binResult);

    }
}

