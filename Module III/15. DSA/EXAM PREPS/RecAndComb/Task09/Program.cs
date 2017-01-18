using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task09
{
    public class Program
    {
        private static int[] tree = new int[1000000];
        private static HashSet<char>[] taken = new HashSet<char>[1000000];
        private static int counter = 0;
        private static int totalCounter = 0;
        private static int len = 0;
        private static string input;

        public static void Main()
        {
            input = "YBB";
            len = input.Length;

            for (int i = 0; i < input.Length; i++)
            {
                var currentChar = input[i];
                var takenChars = new HashSet<int>();
                takenChars.Add(i);
                GenerateTree(currentChar, 0, takenChars);
            }

            Console.WriteLine(totalCounter);
        }

        public static void GenerateTree(char currentChar, int position, HashSet<int> takenChars)
        {
            counter++;
            if(counter == len)
            {
                totalCounter++;
                counter--;
            }

            if (taken[position] == null)
            {
                taken[position] = new HashSet<char>();
            }

            if (!taken[position].Contains(currentChar))
            {
                taken[position].Add(currentChar);
                for (int i = 0; i < input.Length; i++)
                {
                    if (!takenChars.Contains(i))
                    {
                        takenChars.Add(i);
                        GenerateTree(currentChar, position * 2 + 1, takenChars);
                        GenerateTree(currentChar, position * 2 + 2, takenChars);
                        takenChars.Remove(i);
                    }
                }
            }
        }
    }

    public class Node
    {
        public Node()
        {

        }

        public int Position { get; set; }

        public int Parrent { get; set; }

        public int LeftPosition { get { return this.Position * 2 + 1; } }

        public int RightPosition { get { return this.Position * 2 + 2; } }

        public char Value { get; set; }

        public Node Left
        {
            get; set;
        }

        public Node Right
        {
            get; set;
        }
    }
}