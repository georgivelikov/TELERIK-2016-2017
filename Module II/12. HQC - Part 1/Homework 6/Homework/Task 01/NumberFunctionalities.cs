using System;

namespace Methods
{
    /// <summary>
    /// Provides some functionalities for operating numbers
    /// </summary>
    public static class NumberFunctionalities
    {
        public static string NumberToDigit(int number)
        {
            if (number > 9 || number < 0)
            {
                throw new ArgumentException("Input is not a digit");
            }
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default:
                    return "Invalid input";
            }
        }

        public static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentNullException("Invalid array of integers");
            }

            int maxValue = int.MinValue;
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] > maxValue)
                {
                    maxValue = elements[i];
                }
            }

            return maxValue;
        }

        public static void PrintAsNumber(object number, string format)
        {
            if (IsNumber(number))
            {
                if (format == "f")
                {
                    Console.WriteLine("Number as float: {0:f2}", number);
                }
                else if (format == "%")
                {
                    Console.WriteLine("Number as percent with 2 digits precision: {0:p0}", number);
                }
                else if (format == "r")
                {
                    Console.WriteLine("Number eight spaces to the right: {0, 8}", number);
                }
                else
                {
                    throw new InvalidOperationException("Invalid format");
                }
            }
            else
            {
                throw new ArgumentException("Input object is not a number");
            }
        }

        private static bool IsNumber(object number)
        {
            if (number is byte ||
                number is sbyte ||
                number is short ||
                number is ushort ||
                number is int ||
                number is uint ||
                number is long ||
                number is ulong ||
                number is double ||
                number is float ||
                number is decimal)
            {
                return true;
            }

            return false;
        }
    }
}
