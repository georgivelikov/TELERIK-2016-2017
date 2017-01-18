using System;

namespace Task02___Minimum_Edit_Distance
{
    public class Program
    {
        public static void Main()
        {
            var word1 = " developer";
            var word2 = " enveloped";

            var costReplace = 1;
            var costDelete = 0.9;
            var costInsert = 0.8;

            var len1 = word1.Length;
            var len2 = word2.Length;


            double[,] distance = new double[len2, len1];
            double result = 0;

            Console.Write("  ");
            for (int i = 0; i < len1; i++)
            {
                distance[0, i] = i;

                Console.Write(word1[i] + " ");
            }

            for (int i = 0; i < len2; i++)
            {
                distance[i, 0] = i;
            }
            Console.WriteLine();
            //rows = len2
            //cols = len1
            
            for (int i = 1; i < len2; i++)
            {
                for (int j = 1; j < len1; j++)
                {
                    if (word1[j] != word2[i])
                    {
                        var top = distance[i - 1, j];
                        var left = distance[i, j - 1];
                        var diagonal = distance[i - 1, j - 1];

                        var value = Math.Min(Math.Min(diagonal, left), top);

                        distance[i, j] = value + 1;
                    }
                    else
                    {
                        distance[i, j] = distance[i - 1, j - 1];
                    }
                }
            }

            Print(distance, word2);

            var index1 = len1 - 1;
            var index2 = len2 - 1;
            var prev = 0;

            while (true)
            {
                if (index1 == 0 || index2 == 0)
                {
                    break;
                }

                if (distance[index1, index2] == distance[index1 - 1, index2 - 1])
                {
                    index1--;
                    index2--;
                }
                else
                {
                    if (distance[index1, index2] == distance[index1 - 1, index2 - 1] + 1)
                    {
                        result += costDelete;
                        index1--;
                        index2--;
                    }
                    else if (distance[index1, index2] == distance[index1 - 1, index2] + 1)
                    {
                        result += costReplace;
                        index1--;
                    }
                    else if (distance[index1, index2] == distance[index1, index2 - 1] + 1)
                    {
                        result += costInsert;
                        index2--;
                    }
                }               
            }
            
            Console.WriteLine(result);
        }

        private static void Print(double[,] matrix, string word)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write(word[i]);
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(" " + matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
