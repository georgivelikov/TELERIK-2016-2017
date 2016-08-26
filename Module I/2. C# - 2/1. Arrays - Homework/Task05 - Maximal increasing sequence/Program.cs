using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task05___Maximal_increasing_sequence
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                arr[i] = number;
            }

            int maxSeq = 0;
            int currentSeq = 1;

            for (int i = 1; i < n; i++)
            {
                if (arr[i] > arr[i - 1])
                {
                    currentSeq++;
                }
                else
                {
                    if (maxSeq < currentSeq)
                    {
                        maxSeq = currentSeq;
                    }

                    currentSeq = 1;
                }
            }

            if (maxSeq < currentSeq)
            {
                maxSeq = currentSeq;
            }

            Console.WriteLine(maxSeq);
        }
    }
}
