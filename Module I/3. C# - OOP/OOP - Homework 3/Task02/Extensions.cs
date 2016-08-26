namespace Task02
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Extensions
    {
        public static double CustomSum<T>(this IEnumerable<T> list) where T : IComparable, IConvertible
        {
            double sum = 0;

            foreach (var item in list)
            {
                sum += (dynamic)item;
            }

            return sum;
        }

        public static double CustomProduct<T>(this IEnumerable<T> list) where T : IComparable, IConvertible
        {
            double product = 1;

            foreach (var item in list)
            {
                product *= (dynamic)item;
            }

            return product;
        }

        public static double CustomMax<T>(this IEnumerable<T> list) where T : IComparable, IConvertible
        {
            double max = double.MinValue;

            foreach (var item in list)
            {
                if (max < (dynamic)item)
                {
                    max = (dynamic)item;
                }
            }

            return max;
        }

        public static double CustomMin<T>(this IEnumerable<T> list) where T : IComparable, IConvertible
        {
            double min = double.MaxValue;

            foreach (var item in list)
            {
                if (min > (dynamic)item)
                {
                    min = (dynamic)item;
                }
            }

            return min;
        }

        public static double CustomAverage<T>(this IEnumerable<T> list) where T : IComparable, IConvertible
        {
            double avg = 0;

            var sum = list.CustomSum();
            avg = sum / list.Count();

            return avg;
        }
    }
}
