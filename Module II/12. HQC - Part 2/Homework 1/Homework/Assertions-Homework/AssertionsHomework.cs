using System;
using System.Diagnostics;

public class Assertions
{
    public static void Main()
    {
        int[] array = { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("array = [{0}]", string.Join(", ", array));
        SelectionSort(array);
        Console.WriteLine("sorted array = [{0}]", string.Join(", ", array));

        Console.WriteLine(BinarySearch(array, -1000));
        Console.WriteLine(BinarySearch(array, 0));
        Console.WriteLine(BinarySearch(array, 17));
        Console.WriteLine(BinarySearch(array, 10));
        Console.WriteLine(BinarySearch(array, 1000));
    }

    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        Debug.Assert(arr.Length > 0, "Cannot sort empty array");

        for (int index = 0; index < arr.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        return BinarySearchInRange(arr, value, 0, arr.Length - 1);
    }

    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        Debug.Assert(arr.Length > 0, "Cannot search in empty array");
        Debug.Assert(startIndex <= endIndex, "Start index cannot be greater than End index");
        Debug.Assert(0 <= startIndex && startIndex <= arr.Length - 1, "Start index is invalid.");
        Debug.Assert(0 <= endIndex && endIndex <= arr.Length - 1, "End index is invalid.");

        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }
        return minElementIndex;
    }

    private static void Swap<T>(ref T firstValue, ref T secondValue)
    {
        T previousFirstValue = firstValue;
        firstValue = secondValue;
        secondValue = previousFirstValue;
    }

    private static int BinarySearchInRange<T>(T[] arr, T value, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        Debug.Assert(arr.Length > 0, "Cannot search in empty array");
        Debug.Assert(startIndex <= endIndex, "Start index cannot be greater than End index");
        Debug.Assert(0 <= startIndex && startIndex <= arr.Length - 1, "Start index is invalid.");
        Debug.Assert(0 <= endIndex && endIndex <= arr.Length - 1, "End index is invalid.");

        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (arr[midIndex].Equals(value))
            {
                return midIndex;
            }

            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the left half
                startIndex = midIndex + 1;
            }
            else
            {
                // Search on the right half
                endIndex = midIndex - 1;
            }
        }

        // Searched value not found
        return -1;
    }
}

