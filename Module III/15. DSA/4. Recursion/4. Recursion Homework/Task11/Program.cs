using System;
using System.Collections.Generic;

public class Program
{
    private static string[] objects;

    public static void Main()
    {
        //objects = new[] { "1", "3", "5", "5"};
        objects = new[] { "1", "5", "5", "5", "5", "5", "5", "5", "5", "5", "5", "5", "5" };

        GeneratePermutationsFast(0, objects.Length - 1);
    }

    private static void GeneratePermutations(int index = 0) // more memory, easier
    {
        if (index >= objects.Length)
        {
            Print();
        }
        else
        {
            var swapped = new HashSet<string>();
            for (int i = index; i < objects.Length; i++)
            {
                if (!swapped.Contains(objects[i]))
                {
                    Swap(ref objects[index], ref objects[i]);
                    GeneratePermutations(index + 1);
                    Swap(ref objects[index], ref objects[i]);

                    swapped.Add(objects[i]);
                }
            }
        }
    }

    private static void GeneratePermutationsFast(int start, int end) // ARRAY SHOULD BE SORTED !!!!!!!!!!
    {
        Print();

        for (int left = end - 1; left >= start; left--)
        {
            for (int right = left + 1; right <= end; right++)
            {
                if (objects[left] != objects[right])
                {
                    Swap(ref objects[left], ref objects[right]);
                    GeneratePermutationsFast(left + 1, end);
                }
            }

            // Undo all modifications done by the
            // previous recursive calls and swaps
            var firstElement = objects[left];
            for (int i = left; i <= end - 1; i++)
            {
                objects[i] = objects[i + 1];
            }

            objects[end] = firstElement;
        }
    }

    private static void Print()
    {
        Console.WriteLine("{0}", string.Join(", ", objects));
    }

    private static void Swap<T>(ref T first, ref T Fast)
    {
        T oldFirst = first;
        first = Fast;
        Fast = oldFirst;
    }
}



