using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxIncreasingJumps
{
    class JoroTheRabbit
    {
        static void Main()
        {
            int[] numbers = ParseInput();

            int bestPath = int.MinValue;

            for (int startIndex = 0; startIndex < numbers.Length; startIndex++)
            {
                for (int step = 1; step < numbers.Length; step++)
                {
                    int index = startIndex;
                    int currentPath = 1;
                    int next = (index + step) % numbers.Length;

                    while (next != startIndex && numbers[index] < numbers[next])
                    {
                        currentPath++;
                        index = next;
                        next = (index + step) % numbers.Length;
                    }

                    if (bestPath < currentPath)
                    {
                        bestPath = currentPath;
                    }
                }
            }
            Console.WriteLine(bestPath);
        }

        private static int[] ParseInput()
        {
            string[] inputs = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            int[] numbers = new int[inputs.Length];
            for (int i = 0; i < inputs.Length; i++)
            {
                numbers[i] = int.Parse(inputs[i]);
            }
            return numbers;
        }
    }
}
