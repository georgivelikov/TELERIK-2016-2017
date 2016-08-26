using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

public class Program
{
    public static void Main()
    {
        List<int> list = new List<int>();
        while (true)
        {
            string line = Console.ReadLine();
            if (line == "END")
            {
                break;
            }

            int num = int.Parse(line);
            list.Add(num);
            
        }

        int count = 1;

        while (true)
        {
            int firstSum = 0;

            for (int i = 0; i < count; i++)
            {
                firstSum += list[i];
            }

            if (count + firstSum > list.Count)
            {
                break;
            }

            BigInteger sum = 0;
            BigInteger product = 1;
            for (int i = count; i < count + firstSum; i++)
            {
                sum += list[i];
                product *= list[i];
            }

            List<BigInteger> newList = new List<BigInteger>();
            newList.Add(sum);
            newList.Add(product);
            if (count + firstSum != list.Count)
            {
                for (int i = count + firstSum; i < list.Count; i++)
                {
                    newList.Add(list[i]);
                }
            }
            else
            {
                string result1 = string.Join(string.Empty, newList);
                result1 = result1.Replace("1", string.Empty);
                result1 = result1.Replace("0", string.Empty);
                int[] arr1 = result1.ToCharArray().Select(x => int.Parse(x.ToString())).ToArray();
                list = new List<int>(arr1);
                break;
            }
            string result = string.Join(string.Empty, newList);
            result = result.Replace("1", string.Empty);
            result = result.Replace("0", string.Empty);
            int[] arr = result.ToCharArray().Select(x => int.Parse(x.ToString())).ToArray();
            list = new List<int>(arr);
            count++;
        }

        Console.WriteLine(string.Join(" ", list));
    }
}

