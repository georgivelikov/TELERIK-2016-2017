using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static int[] elements;
    private static bool[] used;
    private static int counter = 0;

    public static void Main()
    {
        int[] nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int n = nk[0];
        int k = nk[1];
        elements = new int[n];

        if (k == 1)
        {
            Console.WriteLine(n);
            return;
        }

        for (int i = 0; i < n; i++)
        {
            elements[i] = i;
        }

        int[] arr = new int[k];
        used = new bool[elements.Length + 1];
        GenerateUniqueVariations(arr);

        Console.WriteLine(counter);
    }

    private static void GenerateVariations(int[] arr, int index = 0)
    {
        if (index >= arr.Length)
        {
            //Evaluate(arr);
            counter++;
            PrintVariations(arr);
        }
        else
        {
            for (int i = 0; i < elements.Length; i++)
            {
                if (!used[i])
                {
                    
                }
            }
        }
    }

    private static void GenerateUniqueVariations(int[] arr, int index = 0)
    {
        if (index >= arr.Length)
        {
            counter++;
            PrintVariations(arr);
        }
        else
        {
            var unique = new HashSet<int>();
            for (int i = 0; i < elements.Length; i++)
            {
                if (!unique.Contains(elements[i]))
                {
                    if (!used[i])
                    {
                        if (index != 0)
                        {
                            var prev = elements[arr[index - 1]];
                            var current = elements[arr[index]];
                            if (index % 2 == 0)
                            {
                                if (prev >= current)
                                {
                                    continue;
                                }
                            }
                            else if (index % 2 != 0)
                            {
                                if (prev <= current)
                                {
                                    continue;
                                }
                            }

                            used[i] = true;
                            arr[index] = i;
                            GenerateUniqueVariations(arr, index + 1);
                            used[i] = false;
                            unique.Add(elements[i]);
                        }
                        else
                        {
                            used[i] = true;
                            arr[index] = i;
                            GenerateUniqueVariations(arr, index + 1);
                            used[i] = false;
                            unique.Add(elements[i]);
                        }
                    }
                }
            }
        }
    }

    //private static void Evaluate(int[] arr)
    //{
    //    var result = arr.Select(i => int.Parse(elements[i])).ToArray();

    //    bool isZigZag = true;

    //    for (int i = 0; i < result.Length - 1; i++)
    //    {
    //        if (i % 2 == 0)
    //        {
    //            if (result[i] < result[i + 1])
    //            {
    //                isZigZag = false;
    //            }
    //        }
    //        else
    //        {
    //            if (result[i] > result[i + 1])
    //            {
    //                isZigZag = false;
    //            }
    //        }
    //    }

    //    if (isZigZag)
    //    {
    //        counter++;
    //    }
    //}

    private static void PrintVariations(int[] arr)
    {
        Console.WriteLine("{0}", string.Join(", ", arr.Select(i => elements[i])));
    }
}


