using System;
using System.Collections.Generic;

namespace Task04
{
    public class Program
    {
        // Write a method that finds the longest subsequence of equal numbers in given List and returns the result as new List<int>.

        public static void Main()
        {
            // var list = new List<int>() { 4, 2, 2, 5, 5, 5, 2, 3, 2, 3, 1, 5, 2 };
            // var list = new List<int>() { 4, 4, 4, 4, 4, 2, 2, 5, 5, 5, 2, 3, 2, 3, 1, 5, 2 };
            var list = new List<int>() { 4, 2, 2, 5, 5, 5, 2, 3, 2, 3, 1, 5, 2, 2, 2, 2, 2, 2 };
            var previousNumber = list[0];
            var mostFrequentNumber = list[0];
            var counter = 1;
            var mostFrequentCount = 0;

            for (int i = 1; i < list.Count; i++)
            {
                var currentNumber = list[i];
                if (currentNumber == previousNumber)
                {
                    counter++;
                }
                else
                {
                    if (counter > mostFrequentCount)
                    {
                        mostFrequentCount = counter;
                        mostFrequentNumber = previousNumber;
                    }

                    previousNumber = currentNumber;
                    counter = 1;
                }
            }

            if (counter > mostFrequentCount)
            {
                mostFrequentCount = counter;
                mostFrequentNumber = previousNumber;
            }

            var resultList = new List<int>();
            for (int j = 0; j < mostFrequentCount; j++)
            {
                resultList.Add(mostFrequentNumber);
            }

            Console.WriteLine(string.Join(", ", resultList));
        }
    }
}
