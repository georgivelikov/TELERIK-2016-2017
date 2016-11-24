using System;
using System.Collections.Generic;
using System.Numerics;

namespace Task02
{
    // Задача 2 – Цветни зайци 100/100
    public class Program
    {
        public static void Main()
        {
            int askedRabbits = int.Parse(Console.ReadLine());
            var answers = new BigInteger[askedRabbits];

            for (int i = 0; i < askedRabbits; i++)
            {
                answers[i] = BigInteger.Parse(Console.ReadLine());
            }

            BigInteger rabbitsCounter = 0;

            Dictionary<BigInteger, BigInteger> rabbitsDictionary = new Dictionary<BigInteger, BigInteger>();

            foreach (var answer in answers)
            {
                if (!rabbitsDictionary.ContainsKey(answer + 1))
                {
                    rabbitsDictionary.Add(answer + 1, 0);
                }

                rabbitsDictionary[answer + 1]++;
            }

            foreach (var item in rabbitsDictionary)
            {
                BigInteger key = item.Key;
                BigInteger val = item.Value;
                BigInteger currentCount;

                if (key >= val)
                {
                    currentCount = key;
                }
                else
                {
                    if (key == 0)
                    {
                        currentCount = val;
                    }
                    else
                    {
                        if (val % key != 0)
                        {
                            currentCount = (val / key) * key + key;
                        }
                        else
                        {
                            currentCount = (val / key) * key;
                        }
                    }
                }

                rabbitsCounter += currentCount;
            }

            Console.WriteLine(rabbitsCounter);
        }
    }
}
