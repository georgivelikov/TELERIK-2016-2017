using System;
using System.Collections.Generic;
using System.Text;

public class Utils
{
    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        if (arr.Length == 0)
        {
            throw new ArgumentException("Cannot perform on empty array!");
        }

        if (startIndex < 0)
        {
            throw new ArgumentException("Invalid start index");
        }

        if (startIndex + count > arr.Length)
        {
            throw new ArgumentException("Invalid start index and count");
        }

        List<T> result = new List<T>();

        for (int i = startIndex; i < startIndex + count; i++)
        {
            result.Add(arr[i]);
        }

        return result.ToArray();
    }

    public static string ExtractEnding(string str, int count)
    {
        if (count > str.Length)
        {
            throw new ArgumentException("Ivalid count!");
        }

        if (string.IsNullOrWhiteSpace(str))
        {
            throw new ArgumentNullException("String can not be null or white space!");
        }

        StringBuilder result = new StringBuilder();
        for (int i = str.Length - count; i < str.Length; i++)
        {
            result.Append(str[i]);
        }

        return result.ToString();
    }

    public static void CheckPrime(int number)
    {
        if (number < 1)
        {
            throw new ArgumentException("Prime numbers are only positive numbers");
        }

        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                Console.WriteLine("{0} is not prime", number);
                return;
            }
        }

        Console.WriteLine("{0} is prime", number);
    }
}
