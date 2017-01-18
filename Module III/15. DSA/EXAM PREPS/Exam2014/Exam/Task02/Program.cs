using System;
using System.Collections.Generic;
using System.Linq;

namespace Task02
{
    public class Program
    {
        private static List<string> combo = new List<string>();
        private static List<int> shirts = new List<int>();
        private static List<char> skirts = new List<char>();
        private static List<string> resultHolder = new List<string>();

        public static void Main()
        {
            int k = int.Parse(Console.ReadLine());
            for (int i = 0; i < k; i++)
            {
                shirts.Add(i);
            }

            var input = Console.ReadLine().ToCharArray();
            
            for (int i = 0; i < input.Length; i++)
            {
                skirts.Add(input[i]);
            }
            for (int i = 0; i < shirts.Count; i++)
            {
                var currentShirt = shirts[i].ToString();
                for (int j = 0; j < skirts.Count; j++)
                {
                    var currentSkirt = (char)skirts[j];
                    if (!combo.Contains(currentShirt + "" + currentSkirt))
                    {
                        combo.Add(currentShirt + "" + currentSkirt);
                    }
                }
            }
            skirts.Sort();
            combo.Sort();
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            GenerateCombinations(arr);

            Console.WriteLine(resultHolder.Count);
            if(resultHolder.Count != 0)
            {
                Console.WriteLine(string.Join("\n", resultHolder));
            }
            
        }

        private static void GenerateCombinations(int[] arr, int index = 0, int start = 0)
        {
            if (index >= arr.Length)
            {
                PrintCombinations(arr);
            }
            else
            {
                for (int i = start; i < combo.Count; i++)
                {
                    arr[index] = i;
                    GenerateCombinations(arr, index + 1, i + 1);
                }
            }
        }

        private static void PrintCombinations(int[] arr)
        {
            var newArr = arr.Select(i => combo[i]).ToList();
            var shirtsLeft = new List<int>(shirts);
            var skirtsLeft = new List<char>(skirts);

            bool valid = true;
            for (int i = 0; i < newArr.Count; i++)
            {
                var currentShirt = newArr[i][0] - 48;
                var currentSkirt = newArr[i][1];
                if (!shirtsLeft.Contains(currentShirt))
                {
                    valid = false;
                    break;
                }
                else
                {
                    shirtsLeft.Remove(currentShirt);
                }
                if (!skirtsLeft.Contains(currentSkirt))
                {
                    valid = false;
                    break;
                }
                else
                {
                    skirtsLeft.Remove(currentSkirt);
                }
            }

            if (valid)
            {
                resultHolder.Add(string.Join("-", newArr));
            }
            
        }
    }
}
