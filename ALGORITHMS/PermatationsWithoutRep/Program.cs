using System;

public class Program
{
    // Permutation works with every element of the collection and arange them. 
    // Equals to Variation with repetition, where k == n
    private static string[] objects;

    public static void Main()
    {
        objects = new[] { "1", "2", "3" };

        GeneratePermutations();
    }

    private static void GeneratePermutations(int index = 0)
    {
        if (index >= objects.Length)
        {
            Print();
        }
        else
        {
            GeneratePermutations(index + 1);
            for (int i = index + 1; i < objects.Length; i++)
            {
                Swap(ref objects[index], ref objects[i]);
                GeneratePermutations(index + 1);
                Swap(ref objects[index], ref objects[i]);
            }
        }
    }

    private static void Print()
    {
        Console.WriteLine("{0}", string.Join(", ", objects));
    }

    private static void Swap<T>(ref T first, ref T second)
    {
        T oldFirst = first;
        first = second;
        second = oldFirst;
    }
}



