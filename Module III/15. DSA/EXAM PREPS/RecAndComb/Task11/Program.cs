using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static int[] elements;
    private static int searched;
    private static int counter = 0;

    public static void Main()
    {
        int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int n = input[0];
        searched = input[1];
        elements = new int[n];

        for (int i = 0; i < n; i++)
        {
            elements[i] = i + 1;
        }

        GeneratePermutationsSecond(0, elements.Length - 1);
    }

    private static void GeneratePermutations(int index = 0) // more memory, easier
    {
        if (index >= elements.Length)
        {
            Print();
        }
        else
        {
            var swapped = new HashSet<int>();
            for (int i = index; i < elements.Length; i++)
            {
                if (!swapped.Contains(elements[i]))
                {
                    Swap(ref elements[index], ref elements[i]);
                    GeneratePermutations(index + 1);
                    Swap(ref elements[index], ref elements[i]);

                    swapped.Add(elements[i]);
                }
            }
        }
    }

    private static void GeneratePermutationsSecond(int start, int end) // ARRAY SHOULD BE SORTED !!!!!!!!!!
    {
        Print();

        for (int left = end - 1; left >= start; left--)
        {
            for (int right = left + 1; right <= end; right++)
            {
                if (elements[left] != elements[right])
                {
                    Swap(ref elements[left], ref elements[right]);
                    GeneratePermutationsSecond(left + 1, end);
                }
            }

            // Undo all modifications done by the
            // previous recursive calls and swaps
            var firstElement = elements[left];
            for (int i = left; i <= end - 1; i++)
            {
                elements[i] = elements[i + 1];
            }

            elements[end] = firstElement;
        }
    }

    private static void Print()
    {
        counter++;
        if (searched == counter)
        {
            Console.WriteLine("{0}", string.Join(" ", elements));
            Environment.Exit(0);
        }

    }

    private static void Swap(ref int first, ref int second)
    {
        int oldFirst = first;
        first = second;
        second = oldFirst;
    }
}



