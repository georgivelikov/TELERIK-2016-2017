using System;
using System.Collections.Generic;

public class Program
{
    private static char[] arr;
    private static int counter = 0;

    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        arr = new char[n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = Convert.ToChar(Console.ReadLine());
        }

        Array.Sort(arr);
        GeneratePermutations(0, arr.Length - 1);
        Console.WriteLine(counter);

    }

    private static void GeneratePermutations(int start, int end)
    {
        Validate();

        for (int left = end - 1; left >= start; left--)
        {
            for (int right = left + 1; right <= end; right++)
            {
                if (arr[left] != arr[right])
                {
                    Swap(ref arr[left], ref arr[right]);
                    GeneratePermutations(left + 1, end);
                }
            }

            // Undo all modifications done by the
            // previous recursive calls and swaps
            var firstElement = arr[left];
            for (int i = left; i <= end - 1; i++)
            {
                arr[i] = arr[i + 1];
            }

            arr[end] = firstElement;
        }
    }

    private static void Validate()
    {
        bool valid = true;
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] == arr[i - 1])
            {
                valid = false;
                break;
            }
        }

        if (valid)
        {
            counter++;
        }
    }

    private static void Swap<T>(ref T first, ref T second)
    {
        T oldFirst = first;
        first = second;
        second = oldFirst;
    }
}



