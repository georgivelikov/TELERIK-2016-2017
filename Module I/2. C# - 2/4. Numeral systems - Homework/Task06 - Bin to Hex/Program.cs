using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        string bin = Console.ReadLine();
        string hexNum = "";
        string hexNumRev = "";
        string hexHelpString = "";
        double hexHelpNum = 0;
        int counter = 0;
        for (int i = bin.Length - 1; i >= 0; i--)
        {
            if (bin[i] == '1')
            {
                hexHelpNum += Math.Pow(2, counter);
            }
            counter++;
            if (counter == 4)
            {
                switch ((int)hexHelpNum)
                {
                    case 0: hexNumRev += "0"; break;
                    case 1: hexNumRev += "1"; break;
                    case 2: hexNumRev += "2"; break;
                    case 3: hexNumRev += "3"; break;
                    case 4: hexNumRev += "4"; break;
                    case 5: hexNumRev += "5"; break;
                    case 6: hexNumRev += "6"; break;
                    case 7: hexNumRev += "7"; break;
                    case 8: hexNumRev += "8"; break;
                    case 9: hexNumRev += "9"; break;
                    case 10: hexNumRev += "A"; break;
                    case 11: hexNumRev += "B"; break;
                    case 12: hexNumRev += "C"; break;
                    case 13: hexNumRev += "D"; break;
                    case 14: hexNumRev += "E"; break;
                    case 15: hexNumRev += "F"; break;
                }
                hexHelpNum = 0;
                counter = 0;
            }
            else if (counter == 3 && i == 0)
            {
                switch ((int)hexHelpNum)
                {
                    case 0: hexNumRev += "0"; break;
                    case 1: hexNumRev += "1"; break;
                    case 2: hexNumRev += "2"; break;
                    case 3: hexNumRev += "3"; break;
                    case 4: hexNumRev += "4"; break;
                    case 5: hexNumRev += "5"; break;
                    case 6: hexNumRev += "6"; break;
                    case 7: hexNumRev += "7"; break;
                }
            }
            else if (counter == 2 && i == 0)
            {
                switch ((int)hexHelpNum)
                {
                    case 0: hexNumRev += "0"; break;
                    case 1: hexNumRev += "1"; break;
                    case 2: hexNumRev += "2"; break;
                    case 3: hexNumRev += "3"; break;
                }
            }
            else if (counter == 1 && i == 0)
            {
                switch ((int)hexHelpNum)
                {
                    case 0: hexNumRev += "0"; break;
                    case 1: hexNumRev += "1"; break;
                }
            }
        }
        for (int i = hexNumRev.Length - 1; i >= 0; i--)
        {
            hexNum += hexNumRev[i];
        }

        Console.WriteLine(hexNum);
    }
}

