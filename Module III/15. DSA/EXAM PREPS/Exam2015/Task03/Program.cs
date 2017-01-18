using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    public class Program
    {
        public static void Main()
        {
            // var turns = new List<int>() { 1, 3, 4 };
            var turns = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            turns.Sort();
            var games = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int a = games[0];
            int b = games[1];

            int counter = 0;

            bool[] balls = new bool[b + 1];

            for (int i = 1; i < balls.Length; i++)
            {
                
                for (int j = 0; j < turns.Count; j++)
                {
                    var turn = turns[j];
                    if (i < turn)
                    {
                        continue;
                    }

                    if (!balls[i - turn])
                    {
                        balls[i] = true;
                    }
                    
                }
            }

            for (int i = a; i < balls.Length; i++)
            {
                if (balls[i])
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);

        }
    }
}
