using System;
using System.Collections.Generic;
using System.Linq;

namespace Task01
{
    // 100/100
    public class Program
    {
        public static void Main()
        {
            Dictionary<char, char> leftTurn = new Dictionary<char, char>();
            leftTurn.Add('u', 'l');
            leftTurn.Add('d', 'r');
            leftTurn.Add('l', 'u');
            leftTurn.Add('r', 'd');

            Dictionary<char, char> rightTurn = new Dictionary<char, char>();
            rightTurn.Add('u', 'l');
            rightTurn.Add('d', 'r');
            rightTurn.Add('l', 'd');
            rightTurn.Add('r', 'u');

            int n = int.Parse(Console.ReadLine());
            List<char> baseArr = "urd".ToCharArray().ToList();
            List<char> result = new List<char>();

            for (int t = 0; t < n - 1; t++)
            {
                // turn right baseArr
                baseArr.Reverse();
                for (int i = 0; i < baseArr.Count; i++)
                {
                    result.Add(rightTurn[baseArr[i]]);
                }

                //reverse and connect Up
                result.Add('u');

                baseArr.Reverse();
                // + baseArr 
                result.AddRange(baseArr);

                // connect right
                result.Add('r');

                //+ baseArr
                result.AddRange(baseArr);

                // connectDown
                result.Add('d');

                // reverse baseArr left
                for (int i = 0; i < baseArr.Count; i++)
                {
                    result.Add(leftTurn[baseArr[i]]);
                }

                baseArr.Clear();
                baseArr = new List<char>(result);
                result.Clear();
            }

            Console.WriteLine(string.Join("", baseArr));
        }
    }
}
