using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    public class Program
    {
        public static void Main()
        {
            long[] arr = Console.ReadLine().Split().Select(x => long.Parse(x)).ToArray();

            //int[] arr = new int[] { -5, 5, 1, 8, -4, 1, 2 };
            int startIndex = 1;
            List<long> resultList = new List<long>();

            while (true)
            {
                if (startIndex >= arr.Length)
                {
                    break;
                }

                long result = Math.Abs(arr[startIndex] - arr[startIndex - 1]);
                resultList.Add(result);
                if (result % 2 == 0)
                {
                    startIndex += 2;
                }
                else
                {
                    startIndex++;
                }
            }

            var outputList = resultList.Where(x => x % 2 == 0);

            Console.WriteLine(outputList.Sum());
        }
    }
}
