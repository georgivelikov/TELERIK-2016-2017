﻿using System;

namespace Task05___AlgoAcademy03
{
    class Program
    {
        //100/100 - not mine
        static void Main()
        {
            string expr = Console.ReadLine();
            int N = expr.Length;
            long[,] DP = new long[N + 1, N + 2];
            DP[0, 0] = 1;
            for (int k = 1; k <= N; k++)
            {
                if (expr[k - 1] == '(') DP[k, 0] = 0;
                else DP[k, 0] = DP[k - 1, 1];
                for (int c = 1; c <= N; c++)
                {
                    if (expr[k - 1] == '(') DP[k, c] = DP[k - 1, c - 1];
                    else if (expr[k - 1] == ')') DP[k, c] = DP[k - 1, c + 1];
                    else DP[k, c] = DP[k - 1, c - 1] + DP[k - 1, c + 1];
                }
            }
            Console.WriteLine(DP[N, 0]);
        }
    }
}
