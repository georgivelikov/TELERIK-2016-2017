using System;
using System.Diagnostics;

namespace Task_03_Sorting_Algorithms
{
    public class Start
    {
        private const int maxNumber = 20000000;

        private static Random random = new Random();

        public static void Main(string[] args)
        {
            int n = 1000;
            int[] arr = new int[n];

            // Seed array with random numbers
            for (int i = 0; i < n; i++)
            {
                arr[i] = random.Next(0, maxNumber);
            }

            Console.WriteLine("Selection sort: " + GetPerformanceTimeForSelectionSort(arr));
            Console.WriteLine("Insertion sort: " + GetPerformanceTimeForInsertionSort(arr));
            Console.WriteLine("Quick sort: " + GetPerformanceTimeForQuickSort(arr));
            Console.WriteLine("Merge sort: " + GetPerformanceTimeForMergeSort(arr));
        }

        private static TimeSpan GetPerformanceTimeForSelectionSort(int[] array)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            SortingAlgoritms.SelectionSort(array);
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        private static TimeSpan GetPerformanceTimeForInsertionSort(int[] array)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            SortingAlgoritms.InsertionSort(array);
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        private static TimeSpan GetPerformanceTimeForQuickSort(int[] array)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            SortingAlgoritms.QuickSort(array);
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        private static TimeSpan GetPerformanceTimeForMergeSort(int[] array)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            SortingAlgoritms.MergeSort(array);
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }
    }
}
