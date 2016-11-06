using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Task_02___Performance_of_ops
{
    public class SimpleArithmeticOperations
    {
        private const int NumberOfOperations = 1000000;
        private const int NumberOfTries = 10;

        private const int IntA = 72000;
        private const int IntB = 12;

        private const long LongA = 3423253876;
        private const long LongB = 2;

        private const float FloatA = 2.32444f;
        private const float FloatB = 12.1512f;

        private const double DoubleA = 2.32444;
        private const double DoubleB = 12.1512;

        private const decimal DecimalA = 2.32444m;
        private const decimal DecimalB = 12.1512m;

        /// <summary>
        /// Performs simple tasks like adding numbers 1 million (NumberOfOperations) times and get the time span.
        /// Each time the result is slightly different.
        /// Performs this 10 (NumberOfTries) times to get average results for each task. 
        /// Prints the average on the console.
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("Calculates average time needed for {0:0 000 000} of the following operations:", NumberOfOperations);
            
            //Adding
            List<TimeSpan> addingInt32Results = new List<TimeSpan>();
            List<TimeSpan> addingInt64Results = new List<TimeSpan>();
            List<TimeSpan> addingFloatResults = new List<TimeSpan>();
            List<TimeSpan> addingDoubleResults = new List<TimeSpan>();
            List<TimeSpan> addingDecimalResults = new List<TimeSpan>();

            for (int i = 0; i < NumberOfTries; i++)
            {
               addingInt32Results.Add(GetPerformanceTimeForAddingInt32(IntA, IntB));
               addingInt64Results.Add(GetPerformanceTimeForAddingInt64(LongA, LongB));
               addingFloatResults.Add(GetPerformanceTimeForAddingFloat(FloatA, FloatB));
               addingDoubleResults.Add(GetPerformanceTimeForAddingDouble(DoubleA, DoubleB));
               addingDecimalResults.Add(GetPerformanceTimeForAddingDecimal(DecimalA, DecimalB));
            }

            Console.WriteLine("Average time span for adding:");
            TimeSpan addingInt32Average = CalculateAverageTimeSpan(addingInt32Results);
            Console.WriteLine("{0, -8} {1}", "int:", addingInt32Average);
            TimeSpan addingInt64Average = CalculateAverageTimeSpan(addingInt64Results);
            Console.WriteLine("{0, -8} {1}", "long:", addingInt64Average);
            TimeSpan addingFloatAverage = CalculateAverageTimeSpan(addingFloatResults);
            Console.WriteLine("{0, -8} {1}", "float:", addingFloatAverage);
            TimeSpan addingDoubleAverage = CalculateAverageTimeSpan(addingDoubleResults);
            Console.WriteLine("{0, -8} {1}", "double:", addingDoubleAverage);
            TimeSpan addingDecimalAverage = CalculateAverageTimeSpan(addingDecimalResults);
            Console.WriteLine("{0, -8} {1}", "decimal:", addingDecimalAverage);

            //Substracting
            List<TimeSpan> substractingInt32Results = new List<TimeSpan>();
            List<TimeSpan> substractingInt64Results = new List<TimeSpan>();
            List<TimeSpan> substractingFloatResults = new List<TimeSpan>();
            List<TimeSpan> substractingDoubleResults = new List<TimeSpan>();
            List<TimeSpan> substractingDecimalResults = new List<TimeSpan>();

            for (int i = 0; i < NumberOfTries; i++)
            {
                substractingInt32Results.Add(GetPerformanceTimeForSubstractingInt32(IntA, IntB));
                substractingInt64Results.Add(GetPerformanceTimeForSubstractingInt64(LongA, LongB));
                substractingFloatResults.Add(GetPerformanceTimeForSubstractingFloat(FloatA, FloatB));
                substractingDoubleResults.Add(GetPerformanceTimeForSubstractingDouble(DoubleA, DoubleB));
                substractingDecimalResults.Add(GetPerformanceTimeForSubstractingDecimal(DecimalA, DecimalB));
            }

            Console.WriteLine("Average time span for substracting:");
            TimeSpan substractingInt32Average = CalculateAverageTimeSpan(substractingInt32Results);
            Console.WriteLine("{0, -8} {1}", "int:", substractingInt32Average);
            TimeSpan substractingInt64Average = CalculateAverageTimeSpan(substractingInt64Results);
            Console.WriteLine("{0, -8} {1}", "long:", substractingInt64Average);
            TimeSpan substractingFloatAverage = CalculateAverageTimeSpan(substractingFloatResults);
            Console.WriteLine("{0, -8} {1}", "float:", substractingFloatAverage);
            TimeSpan substractingDoubleAverage = CalculateAverageTimeSpan(substractingDoubleResults);
            Console.WriteLine("{0, -8} {1}", "double:", substractingDoubleAverage);
            TimeSpan substractingDecimalAverage = CalculateAverageTimeSpan(substractingDecimalResults);
            Console.WriteLine("{0, -8} {1}", "decimal:", substractingDecimalAverage);

            //Incrementing Prefix
            List<TimeSpan> incrementingPrefixInt32Results = new List<TimeSpan>();
            List<TimeSpan> incrementingPrefixInt64Results = new List<TimeSpan>();
            List<TimeSpan> incrementingPrefixFloatResults = new List<TimeSpan>();
            List<TimeSpan> incrementingPrefixDoubleResults = new List<TimeSpan>();
            List<TimeSpan> incrementingPrefixDecimalResults = new List<TimeSpan>();

            for (int i = 0; i < NumberOfTries; i++)
            {
                incrementingPrefixInt32Results.Add(GetPerformanceTimeForIncrementingPrefixInt32(IntA));
                incrementingPrefixInt64Results.Add(GetPerformanceTimeForIncrementingPrefixInt64(LongA));
                incrementingPrefixFloatResults.Add(GetPerformanceTimeForIncrementingPrefixFloat(FloatA));
                incrementingPrefixDoubleResults.Add(GetPerformanceTimeForIncrementingPrefixDouble(DoubleA));
                incrementingPrefixDecimalResults.Add(GetPerformanceTimeForIncrementingPrefixDecimal(DecimalA));
            }

            Console.WriteLine("Average time span for incrementing prefix:");
            TimeSpan incrementingPrefixInt32Average = CalculateAverageTimeSpan(incrementingPrefixInt32Results);
            Console.WriteLine("{0, -8} {1}", "int:", incrementingPrefixInt32Average);
            TimeSpan incrementingPrefixInt64Average = CalculateAverageTimeSpan(incrementingPrefixInt64Results);
            Console.WriteLine("{0, -8} {1}", "long:", incrementingPrefixInt64Average);
            TimeSpan incrementingPrefixFloatAverage = CalculateAverageTimeSpan(incrementingPrefixFloatResults);
            Console.WriteLine("{0, -8} {1}", "float:", incrementingPrefixFloatAverage);
            TimeSpan incrementingPrefixDoubleAverage = CalculateAverageTimeSpan(incrementingPrefixDoubleResults);
            Console.WriteLine("{0, -8} {1}", "double:", incrementingPrefixDoubleAverage);
            TimeSpan incrementingPrefixDecimalAverage = CalculateAverageTimeSpan(incrementingPrefixDecimalResults);
            Console.WriteLine("{0, -8} {1}", "decimal:", incrementingPrefixDecimalAverage);

            //Incrementing Postfix
            List<TimeSpan> incrementingPostfixInt32Results = new List<TimeSpan>();
            List<TimeSpan> incrementingPostfixInt64Results = new List<TimeSpan>();
            List<TimeSpan> incrementingPostfixFloatResults = new List<TimeSpan>();
            List<TimeSpan> incrementingPostfixDoubleResults = new List<TimeSpan>();
            List<TimeSpan> incrementingPostfixDecimalResults = new List<TimeSpan>();

            for (int i = 0; i < NumberOfTries; i++)
            {
                incrementingPostfixInt32Results.Add(GetPerformanceTimeForIncrementingPostfixInt32(IntA));
                incrementingPostfixInt64Results.Add(GetPerformanceTimeForIncrementingPostfixInt64(LongA));
                incrementingPostfixFloatResults.Add(GetPerformanceTimeForIncrementingPostfixFloat(FloatA));
                incrementingPostfixDoubleResults.Add(GetPerformanceTimeForIncrementingPostfixDouble(DoubleA));
                incrementingPostfixDecimalResults.Add(GetPerformanceTimeForIncrementingPostfixDecimal(DecimalA));
            }

            Console.WriteLine("Average time span for incrementing postfix:");
            TimeSpan incrementingPostfixInt32Average = CalculateAverageTimeSpan(incrementingPostfixInt32Results);
            Console.WriteLine("{0, -8} {1}", "int:", incrementingPostfixInt32Average);
            TimeSpan incrementingPostfixInt64Average = CalculateAverageTimeSpan(incrementingPostfixInt64Results);
            Console.WriteLine("{0, -8} {1}", "long:", incrementingPostfixInt64Average);
            TimeSpan incrementingPostfixFloatAverage = CalculateAverageTimeSpan(incrementingPostfixFloatResults);
            Console.WriteLine("{0, -8} {1}", "float:", incrementingPostfixFloatAverage);
            TimeSpan incrementingPostfixDoubleAverage = CalculateAverageTimeSpan(incrementingPostfixDoubleResults);
            Console.WriteLine("{0, -8} {1}", "double:", incrementingPostfixDoubleAverage);
            TimeSpan incrementingPostfixDecimalAverage = CalculateAverageTimeSpan(incrementingPostfixDecimalResults);
            Console.WriteLine("{0, -8} {1}", "decimal:", incrementingPostfixDecimalAverage);

            //Multiplying
            List<TimeSpan> multiplyingInt32Results = new List<TimeSpan>();
            List<TimeSpan> multiplyingInt64Results = new List<TimeSpan>();
            List<TimeSpan> multiplyingFloatResults = new List<TimeSpan>();
            List<TimeSpan> multiplyingDoubleResults = new List<TimeSpan>();
            List<TimeSpan> multiplyingDecimalResults = new List<TimeSpan>();

            for (int i = 0; i < NumberOfTries; i++)
            {
                multiplyingInt32Results.Add(GetPerformanceTimeForMultiplyingInt32(IntA, IntB));
                multiplyingInt64Results.Add(GetPerformanceTimeForMultiplyingInt64(LongA, LongB));
                multiplyingFloatResults.Add(GetPerformanceTimeForMultiplyingFloat(FloatA, FloatB));
                multiplyingDoubleResults.Add(GetPerformanceTimeForMultiplyingDouble(DoubleA, DoubleB));
                multiplyingDecimalResults.Add(GetPerformanceTimeForMultiplyingDecimal(DecimalA, DecimalB));
            }

            Console.WriteLine("Average time span for multiplying:");
            TimeSpan multiplyingInt32Average = CalculateAverageTimeSpan(multiplyingInt32Results);
            Console.WriteLine("{0, -8} {1}", "int:", multiplyingInt32Average);
            TimeSpan multiplyingInt64Average = CalculateAverageTimeSpan(multiplyingInt64Results);
            Console.WriteLine("{0, -8} {1}", "long:", multiplyingInt64Average);
            TimeSpan multiplyingFloatAverage = CalculateAverageTimeSpan(multiplyingFloatResults);
            Console.WriteLine("{0, -8} {1}", "float:", multiplyingFloatAverage);
            TimeSpan multiplyingDoubleAverage = CalculateAverageTimeSpan(multiplyingDoubleResults);
            Console.WriteLine("{0, -8} {1}", "double:", multiplyingDoubleAverage);
            TimeSpan multiplyingDecimalAverage = CalculateAverageTimeSpan(multiplyingDecimalResults);
            Console.WriteLine("{0, -8} {1}", "decimal:", multiplyingDecimalAverage);

            //Divide
            List<TimeSpan> dividingInt32Results = new List<TimeSpan>();
            List<TimeSpan> dividingInt64Results = new List<TimeSpan>();
            List<TimeSpan> dividingFloatResults = new List<TimeSpan>();
            List<TimeSpan> dividingDoubleResults = new List<TimeSpan>();
            List<TimeSpan> dividingDecimalResults = new List<TimeSpan>();

            for (int i = 0; i < NumberOfTries; i++)
            {
                dividingInt32Results.Add(GetPerformanceTimeForDividingInt32(IntA, IntB));
                dividingInt64Results.Add(GetPerformanceTimeForDividingInt64(LongA, LongB));
                dividingFloatResults.Add(GetPerformanceTimeForDividingFloat(FloatA, FloatB));
                dividingDoubleResults.Add(GetPerformanceTimeForDividingDouble(DoubleA, DoubleB));
                dividingDecimalResults.Add(GetPerformanceTimeForDividingDecimal(DecimalA, DecimalB));
            }

            Console.WriteLine("Average time span for dividing:");
            TimeSpan dividingInt32Average = CalculateAverageTimeSpan(dividingInt32Results);
            Console.WriteLine("{0, -8} {1}", "int:", dividingInt32Average);
            TimeSpan dividingInt64Average = CalculateAverageTimeSpan(dividingInt64Results);
            Console.WriteLine("{0, -8} {1}", "long:", dividingInt64Average);
            TimeSpan dividingFloatAverage = CalculateAverageTimeSpan(dividingFloatResults);
            Console.WriteLine("{0, -8} {1}", "float:", dividingFloatAverage);
            TimeSpan dividingDoubleAverage = CalculateAverageTimeSpan(dividingDoubleResults);
            Console.WriteLine("{0, -8} {1}", "double:", dividingDoubleAverage);
            TimeSpan dividingDecimalAverage = CalculateAverageTimeSpan(dividingDecimalResults);
            Console.WriteLine("{0, -8} {1}", "decimal:", dividingDecimalAverage);
        }

        //Method for calculating average TimeSpan, from StackOverflow
        static TimeSpan CalculateAverageTimeSpan(List<TimeSpan> list)
        {
            double doubleAverageTicks = list.Average(timeSpan => timeSpan.Ticks);
            long longAverageTicks = Convert.ToInt64(doubleAverageTicks);

            return new TimeSpan(longAverageTicks);
        }

        //Add
        static TimeSpan GetPerformanceTimeForAddingInt32(int numberA, int numberB)
        {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int result;

            for (int i = 0; i < NumberOfOperations; i++)
            {
                result = numberA + numberB;
            }
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        static TimeSpan GetPerformanceTimeForAddingInt64(long numberA, long numberB)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            long result;

            for (int i = 0; i < NumberOfOperations; i++)
            {
                result = numberA + numberB;
            }

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        static TimeSpan GetPerformanceTimeForAddingFloat(float numberA, float numberB)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            float result;

            for (int i = 0; i < NumberOfOperations; i++)
            {
                result = numberA + numberB;
            }

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        static TimeSpan GetPerformanceTimeForAddingDouble(double numberA, double numberB)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            double result;

            for (int i = 0; i < NumberOfOperations; i++)
            {
                result = numberA + numberB;
            }

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        static TimeSpan GetPerformanceTimeForAddingDecimal(decimal numberA, decimal numberB)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            decimal result;

            for (int i = 0; i < NumberOfOperations; i++)
            {
                result = numberA + numberB;
            }

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        //Substract
        static TimeSpan GetPerformanceTimeForSubstractingInt32(int numberA, int numberB)
        {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int result;

            for (int i = 0; i < NumberOfOperations; i++)
            {
                result = numberA - numberB;
            }
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        static TimeSpan GetPerformanceTimeForSubstractingInt64(long numberA, long numberB)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            long result;

            for (int i = 0; i < NumberOfOperations; i++)
            {
                result = numberA - numberB;
            }

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        static TimeSpan GetPerformanceTimeForSubstractingFloat(float numberA, float numberB)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            float result;

            for (int i = 0; i < NumberOfOperations; i++)
            {
                result = numberA - numberB;
            }

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        static TimeSpan GetPerformanceTimeForSubstractingDouble(double numberA, double numberB)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            double result;

            for (int i = 0; i < NumberOfOperations; i++)
            {
                result = numberA - numberB;
            }

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        static TimeSpan GetPerformanceTimeForSubstractingDecimal(decimal numberA, decimal numberB)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            decimal result;

            for (int i = 0; i < NumberOfOperations; i++)
            {
                result = numberA - numberB;
            }

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        //Increment Prefix
        static TimeSpan GetPerformanceTimeForIncrementingPrefixInt32(int numberA)
        {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < NumberOfOperations; i++)
            {
                ++numberA;
            }
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        static TimeSpan GetPerformanceTimeForIncrementingPrefixInt64(long numberA)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            long result;

            for (int i = 0; i < NumberOfOperations; i++)
            {
                ++numberA;
            }

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        static TimeSpan GetPerformanceTimeForIncrementingPrefixFloat(float numberA)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            float result;

            for (int i = 0; i < NumberOfOperations; i++)
            {
                ++numberA;
            }

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        static TimeSpan GetPerformanceTimeForIncrementingPrefixDouble(double numberA)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            double result;

            for (int i = 0; i < NumberOfOperations; i++)
            {
                ++numberA;
            }

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        static TimeSpan GetPerformanceTimeForIncrementingPrefixDecimal(decimal numberA)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            decimal result;

            for (int i = 0; i < NumberOfOperations; i++)
            {
                ++numberA;
            }

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        //Increment Postfix
        static TimeSpan GetPerformanceTimeForIncrementingPostfixInt32(int numberA)
        {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < NumberOfOperations; i++)
            {
                numberA++;
            }
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        static TimeSpan GetPerformanceTimeForIncrementingPostfixInt64(long numberA)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            long result;

            for (int i = 0; i < NumberOfOperations; i++)
            {
                numberA++;
            }

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        static TimeSpan GetPerformanceTimeForIncrementingPostfixFloat(float numberA)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            float result;

            for (int i = 0; i < NumberOfOperations; i++)
            {
                numberA++;
            }

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        static TimeSpan GetPerformanceTimeForIncrementingPostfixDouble(double numberA)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            double result;

            for (int i = 0; i < NumberOfOperations; i++)
            {
                numberA++;
            }

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        static TimeSpan GetPerformanceTimeForIncrementingPostfixDecimal(decimal numberA)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            decimal result;

            for (int i = 0; i < NumberOfOperations; i++)
            {
                numberA++;
            }

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        //Multiply
        static TimeSpan GetPerformanceTimeForMultiplyingInt32(int numberA, int numberB)
        {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int result;

            for (int i = 0; i < NumberOfOperations; i++)
            {
                result = numberA * numberB;
            }
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        static TimeSpan GetPerformanceTimeForMultiplyingInt64(long numberA, long numberB)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            long result;

            for (int i = 0; i < NumberOfOperations; i++)
            {
                result = numberA * numberB;
            }

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        static TimeSpan GetPerformanceTimeForMultiplyingFloat(float numberA, float numberB)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            float result;

            for (int i = 0; i < NumberOfOperations; i++)
            {
                result = numberA * numberB;
            }

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        static TimeSpan GetPerformanceTimeForMultiplyingDouble(double numberA, double numberB)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            double result;

            for (int i = 0; i < NumberOfOperations; i++)
            {
                result = numberA * numberB;
            }

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        static TimeSpan GetPerformanceTimeForMultiplyingDecimal(decimal numberA, decimal numberB)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            decimal result;

            for (int i = 0; i < NumberOfOperations; i++)
            {
                result = numberA * numberB;
            }

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        //Divide

        static TimeSpan GetPerformanceTimeForDividingInt32(int numberA, int numberB)
        {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int result;

            for (int i = 0; i < NumberOfOperations; i++)
            {
                result = numberA / numberB;
            }
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        static TimeSpan GetPerformanceTimeForDividingInt64(long numberA, long numberB)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            long result;

            for (int i = 0; i < NumberOfOperations; i++)
            {
                result = numberA / numberB;
            }

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        static TimeSpan GetPerformanceTimeForDividingFloat(float numberA, float numberB)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            float result;

            for (int i = 0; i < NumberOfOperations; i++)
            {
                result = numberA / numberB;
            }

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        static TimeSpan GetPerformanceTimeForDividingDouble(double numberA, double numberB)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            double result;

            for (int i = 0; i < NumberOfOperations; i++)
            {
                result = numberA / numberB;
            }

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        static TimeSpan GetPerformanceTimeForDividingDecimal(decimal numberA, decimal numberB)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            decimal result;

            for (int i = 0; i < NumberOfOperations; i++)
            {
                result = numberA / numberB;
            }

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }
    }
}
