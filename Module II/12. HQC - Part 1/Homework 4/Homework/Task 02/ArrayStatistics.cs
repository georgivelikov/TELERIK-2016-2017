using System;

namespace Task_02
{
    public static class ArrayStatistics
    {
        public static void PrintStatistics(double[] array, IWriter writer)
        {
            double max = FindMax(array);
            double min = FindMin(array);
            double average = FindAverage(array);

            string maxLine = string.Format("Array max value is: {0:f2}", max);
            string minLine = string.Format("Array min value is: {0:f2}", min);
            string averageLine = string.Format("Array average value is: {0:f2}", average);
            
            writer.WriteLine(maxLine);
            writer.WriteLine(minLine);
            writer.WriteLine(averageLine);
        }

        public static double FindMax(double[] array)
        {
            var max = double.MinValue;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }

            return max;
        }

        public static double FindMin(double[] array)
        {
            var min = double.MaxValue;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }

            return min;
        }

        public static double FindAverage(double[] array)
        {
            double sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            double average = sum / array.Length;

            return average;
        }
    }
}
