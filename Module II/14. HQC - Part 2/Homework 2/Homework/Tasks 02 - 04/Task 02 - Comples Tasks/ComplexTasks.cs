using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Task_02___Performance_of_ops
{
    public class ComplexTasks
    {
        private const int NumberOfOperations = 1000000;
        private const int NumberOfTries = 10;

        private const float FloatA = 32.32444f;
        private const double DoubleA = 32.32444;
        private const decimal DecimalA = 32.32444m;

        /// <summary>
        /// Performs complex mathematical tasks 1 million (NumberOfOperations) times and get the time span.
        /// Each time the result is slightly different.
        /// Performs this 10 (NumberOfTries) times to get average results for each task. 
        /// Prints the average on the console.
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("Calculates average time needed for {0:0 000 000} of the following operations:", NumberOfOperations);
            
            // Math.Sqrt
            List<TimeSpan> sqrtFloatResults = new List<TimeSpan>();
            List<TimeSpan> sqrtDoubleResults = new List<TimeSpan>();
            List<TimeSpan> sqrtDecimalResults = new List<TimeSpan>();

            for (int i = 0; i < NumberOfTries; i++)
            {
                sqrtFloatResults.Add(GetPerformanceTimeForSqrtFloat(FloatA));
                sqrtDoubleResults.Add(GetPerformanceTimeForSqrtDouble(DoubleA));
                sqrtDecimalResults.Add(GetPerformanceTimeForSqrtDecimal(DecimalA));
            }

            Console.WriteLine("Average time span for Math.Sqrt:");
            TimeSpan sqrtFloatAverage = CalculateAverageTimeSpan(sqrtFloatResults);
            Console.WriteLine("{0, -8} {1}", "float:", sqrtFloatAverage);
            TimeSpan sqrtDoubleAverage = CalculateAverageTimeSpan(sqrtDoubleResults);
            Console.WriteLine("{0, -8} {1}", "double:", sqrtDoubleAverage);
            TimeSpan sqrtDecimalAverage = CalculateAverageTimeSpan(sqrtDecimalResults);
            Console.WriteLine("{0, -8} {1}", "decimal:", sqrtDecimalAverage);

            // Math.Log
            List<TimeSpan> logFloatResults = new List<TimeSpan>();
            List<TimeSpan> logDoubleResults = new List<TimeSpan>();
            List<TimeSpan> logDecimalResults = new List<TimeSpan>();

            for (int i = 0; i < NumberOfTries; i++)
            {
                logFloatResults.Add(GetPerformanceTimeForLogFloat(FloatA));
                logDoubleResults.Add(GetPerformanceTimeForLogDouble(DoubleA));
                logDecimalResults.Add(GetPerformanceTimeForLogDecimal(DecimalA));
            }

            Console.WriteLine("Average time span for Math.Log:");
            TimeSpan logFloatAverage = CalculateAverageTimeSpan(logFloatResults);
            Console.WriteLine("{0, -7} {1}", "float", logFloatAverage);
            TimeSpan logDoubleAverage = CalculateAverageTimeSpan(logDoubleResults);
            Console.WriteLine("{0, -7} {1}", "double", logDoubleAverage);
            TimeSpan logDecimalAverage = CalculateAverageTimeSpan(logDecimalResults);
            Console.WriteLine("{0, -7} {1}", "decimal", logDecimalAverage);

            // Math.Sin
            List<TimeSpan> sinFloatResults = new List<TimeSpan>();
            List<TimeSpan> sinDoubleResults = new List<TimeSpan>();
            List<TimeSpan> sinDecimalResults = new List<TimeSpan>();

            for (int i = 0; i < NumberOfTries; i++)
            {
                sinFloatResults.Add(GetPerformanceTimeForSinFloat(FloatA));
                sinDoubleResults.Add(GetPerformanceTimeForSinDouble(DoubleA));
                sinDecimalResults.Add(GetPerformanceTimeForSinDecimal(DecimalA));
            }

            Console.WriteLine("Average time span for Math.Sin:");
            TimeSpan sinFloatAverage = CalculateAverageTimeSpan(sinFloatResults);
            Console.WriteLine("{0, -7} {1}", "float", sinFloatAverage);
            TimeSpan sinDoubleAverage = CalculateAverageTimeSpan(sinDoubleResults);
            Console.WriteLine("{0, -7} {1}", "double", sinDoubleAverage);
            TimeSpan sinDecimalAverage = CalculateAverageTimeSpan(sinDecimalResults);
            Console.WriteLine("{0, -7} {1}", "decimal", sinDecimalAverage);
        }

        // Method for calculating average TimeSpan, from StackOverflow
        public static TimeSpan CalculateAverageTimeSpan(List<TimeSpan> list)
        {
            double doubleAverageTicks = list.Average(timeSpan => timeSpan.Ticks);
            long longAverageTicks = Convert.ToInt64(doubleAverageTicks);

            return new TimeSpan(longAverageTicks);
        }

        // Square Root
        public static TimeSpan GetPerformanceTimeForSqrtFloat(float number)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < NumberOfOperations; i++)
            {
                Math.Sqrt(number);
            }

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        public static TimeSpan GetPerformanceTimeForSqrtDouble(double number)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < NumberOfOperations; i++)
            {
                Math.Sqrt(number);
            }

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        public static TimeSpan GetPerformanceTimeForSqrtDecimal(decimal number)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < NumberOfOperations; i++)
            {
                Math.Sqrt((double)number);
            }

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        // Natural Logarithm
        public static TimeSpan GetPerformanceTimeForLogFloat(float number)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < NumberOfOperations; i++)
            {
                Math.Log(number, Math.E);
            }

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        public static TimeSpan GetPerformanceTimeForLogDouble(double number)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < NumberOfOperations; i++)
            {
                Math.Log(number, Math.E);
            }

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        public static TimeSpan GetPerformanceTimeForLogDecimal(decimal number)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < NumberOfOperations; i++)
            {
                Math.Log((double)number, Math.E);
            }

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        // Sin
        public static TimeSpan GetPerformanceTimeForSinFloat(float number)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < NumberOfOperations; i++)
            {
                Math.Sin(number);
            }

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        public static TimeSpan GetPerformanceTimeForSinDouble(double number)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < NumberOfOperations; i++)
            {
                Math.Sin(number);
            }

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        public static TimeSpan GetPerformanceTimeForSinDecimal(decimal number)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < NumberOfOperations; i++)
            {
                Math.Sin((double)number);
            }

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }
    }
}

