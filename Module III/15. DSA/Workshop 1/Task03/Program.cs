using System;

namespace Task03
{
    // 100/100
    public class Program
    {
        private static int n;

        private static char[] relations;

        private static int k;

        private static int[] objects;

        private static int counter;

        private static bool zeroTaken;

        public static void Main()
        {
            n = int.Parse(Console.ReadLine());

            relations = Console.ReadLine().ToCharArray();

            k = int.Parse(Console.ReadLine());

            objects = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

            int[] array = new int[n];

            GenerateVariations(array, 0);

            counter = 0;
        }

        private static void GenerateVariations(int[] array, int prevIndex, int index = 0, int relIndex = -1)
        {
            if (index >= array.Length)
            {
                counter++;
                if (counter == k)
                {
                    Console.WriteLine(string.Join("", array));
                    Environment.Exit(0);
                }
            }
            else
            {
                if (relIndex == -1)
                {
                    if (!zeroTaken)
                    {
                        array[index] = 0;
                        zeroTaken = true;
                        GenerateVariations(array, 9, index + 1, relIndex + 1);
                        zeroTaken = false;
                    }
                    for (int i = 0; i < objects.Length - 1; i++)
                    {
                        array[index] = objects[i];
                        GenerateVariations(array, i, index + 1, relIndex + 1);
                    }
                }
                else
                {
                    if (relations[relIndex] == '>')
                    {
                        if (array[index - 1] != 0)
                        {
                            array[index] = 0;
                            GenerateVariations(array, 9, index + 1, relIndex + 1);
                        }

                        for (int i = prevIndex + 1; i < objects.Length - 1; i++)
                        {
                            array[index] = objects[i];
                            GenerateVariations(array, i, index + 1, relIndex + 1);
                        }

                    }
                    else if (relations[relIndex] == '<')
                    {
                        for (int i = 0; i < prevIndex; i++)
                        {
                            array[index] = objects[i];
                            GenerateVariations(array, i, index + 1, relIndex + 1);
                        }
                    }
                    else
                    {
                        array[index] = array[index - 1];
                        GenerateVariations(array, prevIndex, index + 1, relIndex + 1);
                    }
                }
            }
        }
    }
}