using System;
using System.Linq;
using System.Numerics;

namespace Task03___AlgoAcademy01
{
    // 100/100
    public class Program
    {
        public static void Main()
        {
            BigInteger[] numbers = Console.ReadLine().Split(' ').Select(n => BigInteger.Parse(n)).ToArray();

            var first = numbers[0];
            var second = numbers[1];
            var third = numbers[2];
            var k = (int)numbers[3];
            if (k < 4)
            {
                if (k == 1)
                {
                    Console.WriteLine(first);
                    return;
                }
                else if (k == 2)
                {
                    Console.WriteLine(second);
                    return;
                }
                else if (k == 3)
                {
                    Console.WriteLine(third);
                    return;
                }
            }
            var firstSum = first + second + third;
            var memory = new BigInteger[k];
            memory[0] = first;
            memory[1] = second;
            memory[2] = third;
            memory[3] = firstSum;
            
            for (int i = 4; i < k; i++)
            {
                memory[i] = memory[i - 1] + memory[i - 2] + memory[i - 3];
            }

            Console.WriteLine(memory[k - 1]);
        }
    }
}
