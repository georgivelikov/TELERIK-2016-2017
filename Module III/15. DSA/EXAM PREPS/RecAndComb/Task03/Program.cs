using System;
using System.Collections.Generic;

public class Program
{
    private static string[] objects;
    private static int min = int.MaxValue;
    private static int minCounter = int.MaxValue;

    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        objects = new string[n];

        for (int i = 0; i < n; i++)
        {
            objects[i] = Console.ReadLine();
        }

        Array.Sort(objects);

        GeneratePermutationsSecond(0, objects.Length - 1);

        Console.WriteLine(min);
    }

    private static void GeneratePermutations(int index = 0) // more memory, easier
    {
        if (index >= objects.Length)
        {
            //Print();
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

    private static void GeneratePermutationsSecond(int start, int end) // ARRAY SHOULD BE SORTED !!!!!!!!!!
    {
        Evaluate();

        for (int left = end - 1; left >= start; left--)
        {
            for (int right = left + 1; right <= end; right++)
            {
                if (objects[left] != objects[right])
                {
                    Swap(ref objects[left], ref objects[right]);
                    GeneratePermutationsSecond(left + 1, end);
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

    private static void Evaluate()
    {
        var number = int.Parse(string.Join("", objects));
        //Console.WriteLine(number);
        int counter = 0;
        for (int i = 1; i <= number; i++)
        {
            if(number % i == 0)
            {
                counter++;
            }
        }

        if(counter < minCounter)
        {
            min = number;
            minCounter = counter;
        }
    }

    private static void Swap<T>(ref T first, ref T second)
    {
        T oldFirst = first;
        first = second;
        second = oldFirst;
    }
}



