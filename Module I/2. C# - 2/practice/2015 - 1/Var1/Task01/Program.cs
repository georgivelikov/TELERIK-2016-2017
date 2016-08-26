using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    public class Program
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split();
            double num = 23;
            double outputSum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char[] arr = input[i].ToCharArray();
                double currentOutputSum = 0;
                for (int j = 0; j < arr.Length; j++)
                {
                    double index = arr.Length - 1 - j;
                    currentOutputSum += (arr[j] - 97) * Math.Pow(num, index);
                }

                outputSum += currentOutputSum;
            }

            int sum = (int)outputSum;
            int helper = 0;
            StringBuilder outputWord = new StringBuilder();

            while (sum > 0)
            {
                helper = sum % (int)num;
                sum /= (int)num;
                outputWord.Append((char)(helper + 97));
            }

            char[] charArr = outputWord.ToString().ToCharArray();
            Array.Reverse(charArr);
            string result = new string(charArr);
            Console.WriteLine("{0} = {1}", result, outputSum);
        }
    }
}