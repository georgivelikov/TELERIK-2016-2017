using System;
using System.Collections.Generic;
using System.Diagnostics;

public class TwoIsBetterThanOne
{
    private static void Main()
    {
        // First task
        long lowerBound, upperBound;
        string firstTaskInput = Console.ReadLine();
        var firstTaskInputParts = firstTaskInput.Split(' ');
        lowerBound = long.Parse(firstTaskInputParts[0]);
        upperBound = long.Parse(firstTaskInputParts[1]);
        Console.WriteLine(FindNumberOfLuckyNumber(lowerBound, upperBound));

        // Second task
        string secondTaskNumbersList = Console.ReadLine();
        var secondTaskNumbersListParts = secondTaskNumbersList.Split(',');
        var listOfNumber = new List<int>();
        foreach (var numberAsString in secondTaskNumbersListParts)
        {
            listOfNumber.Add(int.Parse(numberAsString));
        }
        int percentile = int.Parse(Console.ReadLine());
        Console.WriteLine(FindElementFromSecondTask(listOfNumber, percentile));
    }

    #region First task
    private static int FindNumberOfLuckyNumber(long lowerBound, long upperBound)
    {
        long maxNumber = (long)Math.Pow(10, 18);

        int left = 0;
        var numbers = new List<long> { 3, 5 }; // We are using "numbers" as a Queue

        while (left < numbers.Count)
        {
            int right = numbers.Count;
            for (int i = left; i < right; i++)
            {
                if (numbers[i] <= maxNumber)
                {
                    numbers.Add((numbers[i] * 10) + 3);
                    numbers.Add((numbers[i] * 10) + 5);
                }
            }

            left = right;
        }

        int count = 0;
        foreach (var number in numbers)
        {
            if (number >= lowerBound && number <= upperBound && IsPalindromeNumber(number))
            {
                count++;
            }
        }

        return count;
    }

    private static bool IsPalindromeNumberUsingMath(long number)
    {
        long powOf10 = (long)Math.Pow(10, (long)Math.Log10(number));
        while (number > 0)
        {
            if (number % 10 != (number / powOf10))
            {
                return false;
            }

            number = number % powOf10;
            number /= 10;
            powOf10 /= 100;
        }

        return true;
    }

    private static bool IsPalindromeNumber(long number)
    {
        string numberAsString = number.ToString();
        for (int i = 0; i < numberAsString.Length / 2; i++)
        {
            if (numberAsString[i] != numberAsString[numberAsString.Length - i - 1])
            {
                return false;
            }
        }

        return true;
    }
    #endregion

    #region Second task
    private static int FindElementFromSecondTask(List<int> numbers, int percentile)
    {
        numbers.Sort();

        for (int i = 0; i < numbers.Count; i++)
        {
            // int countOfSmallerOrEqualNumber = numbers.Count(t => numbers[i] >= t);
            int countOfSmallerOrEqualNumber = 0;
            for (int j = 0; j < numbers.Count; j++)
            {
                if (numbers[i] >= numbers[j])
                {
                    countOfSmallerOrEqualNumber++;
                }
            }

            if (countOfSmallerOrEqualNumber >= numbers.Count * (percentile / 100.0))
            {
                return numbers[i];
            }
        }

        return numbers[numbers.Count - 1];
    }
    #endregion
}
