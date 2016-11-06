using System;
using System.Collections.Generic;
using System.Numerics;

public class Program
{
    private static Dictionary<string, int> stringToNumberMap;

    private static Dictionary<BigInteger, string> numberToStringMap;

    public static void Main()
    {
        char[] firstSequence = Console.ReadLine().ToCharArray();
        string sign = Console.ReadLine();
        char[] secondSequence = Console.ReadLine().ToCharArray();

        stringToNumberMap = new Dictionary<string, int>();
        stringToNumberMap.Add("cad", 0);
        stringToNumberMap.Add("xoz", 1);
        stringToNumberMap.Add("nop", 2);
        stringToNumberMap.Add("cyk", 3);
        stringToNumberMap.Add("min", 4);
        stringToNumberMap.Add("mar", 5);
        stringToNumberMap.Add("kon", 6);
        stringToNumberMap.Add("iva", 7);
        stringToNumberMap.Add("ogi", 8);
        stringToNumberMap.Add("yan", 9);

        numberToStringMap = new Dictionary<BigInteger, string>();
        numberToStringMap.Add(0, "cad");
        numberToStringMap.Add(1, "xoz");
        numberToStringMap.Add(2, "nop");
        numberToStringMap.Add(3, "cyk");
        numberToStringMap.Add(4, "min");
        numberToStringMap.Add(5, "mar");
        numberToStringMap.Add(6, "kon");
        numberToStringMap.Add(7, "iva");
        numberToStringMap.Add(8, "ogi");
        numberToStringMap.Add(9, "yan");

        int defaultPatternLength = 3;

        BigInteger firstStringAsNumber = ConvertStringToNumber(firstSequence, defaultPatternLength);
        BigInteger secondStringAsNumber = ConvertStringToNumber(secondSequence, defaultPatternLength);
        
        BigInteger resultFromOperation = 0;
        if (sign == "-")
        {
            resultFromOperation = firstStringAsNumber - secondStringAsNumber;
        }
        else
        {
            resultFromOperation = firstStringAsNumber + secondStringAsNumber;
        }

        string finalString = string.Empty;
        while (resultFromOperation > 0)
        {
            BigInteger currentNum = resultFromOperation % 10;
            finalString = numberToStringMap[currentNum] + finalString;
            resultFromOperation /= 10;
        }

        Console.WriteLine(finalString);
    }

    public static BigInteger ConvertStringToNumber(char[] charArray, int defaultPatternLength)
    {
        string currentSequence = string.Empty;
        BigInteger counter = 1;
        BigInteger result = 0;

        for (int i = charArray.Length - 1; i >= 0; i -= defaultPatternLength)
        {
            for (int j = i; j > i - defaultPatternLength; j--)
            {
                currentSequence = charArray[j] + currentSequence;
            }

            int num = stringToNumberMap[currentSequence];
            result += counter * num;
            currentSequence = string.Empty;
            counter *= 10;
        }

        return result;
    } 
}

