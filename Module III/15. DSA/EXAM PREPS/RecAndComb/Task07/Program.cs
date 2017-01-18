using System;
using System.Collections.Generic;

public class Program
{
    private static char[] elements;
    private static HashSet<string> set = new HashSet<string>();
    private static HashSet<string> uniqueCircles = new HashSet<string>();
    private static int counter = 0;
    private static int n = 0;

    public static void Main()
    {
        elements = Console.ReadLine().ToCharArray();
        n = elements.Length;

        GeneratePermutationsSecond(0, elements.Length - 1);
        Console.WriteLine(uniqueCircles.Count);
        //Console.WriteLine(string.Join(" -> ", uniqueCircles));
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
        var line = string.Join("", elements);
        if (!set.Contains(line))
        {
            set.Add(line);

            var newElements = (char[])elements.Clone();
            var list = new LinkedList<char>(newElements);
            Array.Reverse(newElements);
            var list2 = new LinkedList<char>(newElements);

            for (int i = 0; i < n; i++)
            {
                var first = list.First;
                list.RemoveFirst();
                list.AddLast(first);

                var first2 = list2.First;
                list2.RemoveFirst();
                list2.AddLast(first2);

                var newLine = string.Join("", list);
                var newLine2 = string.Join("", list2);

                if (!set.Contains(newLine))
                {
                    set.Add(newLine);
                }

                if (!set.Contains(newLine2))
                {
                    set.Add(newLine2);
                }
            }

            uniqueCircles.Add(line);
        }
    }

    
    private static void Swap<T>(ref T first, ref T second)
    {
        T oldFirst = first;
        first = second;
        second = oldFirst;
    }
}



