using System;
using System.Numerics;
using System.Runtime.InteropServices;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        long[,] matrix = new long[n, n];
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = long.Parse(input[j]);
            }
        }

        BigInteger currentSum = 0;
        BigInteger max = -3000000000000000000;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                currentSum = 0;
                if (j + 4 < n)
                {
                    if (i + 2 < n)
                    {
                        bool first = true;
                        bool second = true;
                        bool third = true;
                        long prev = matrix[i, j];
                        long current = matrix[i, j];
                        currentSum += current;
                        for (int k = 1; k < 3; k++)
                        {
                            current = matrix[i, j + k];
                            if (prev == current - 1)
                            {
                                currentSum += current;
                                prev = current;
                            }
                            else
                            {
                                first = false;
                                break;
                            }
                        }

                        if (first)
                        {
                            for (int k = 0; k < 2; k++)
                            {
                                current = matrix[i + k + 1, j + 2];
                                if (prev == current - 1)
                                {
                                    currentSum += current;
                                    prev = current;
                                }
                                else
                                {
                                    second = false;
                                    break;
                                }
                            }
                        }

                        if (first && second)
                        {
                            for (int k = 0; k < 2; k++)
                            {
                                current = matrix[i + 2, j + 3 + k];
                                if (prev == current - 1)
                                {
                                    currentSum += current;
                                    prev = current;
                                }
                                else
                                {
                                    third = false;
                                    break;
                                }
                            }
                        }

                        if (first && second && third)
                        {
                            if (currentSum > max)
                            {
                                max = currentSum;
                            }
                        }

                    }
                }
            }
        }

        if (max != -3000000000000000000)
        {
            Console.WriteLine("YES " + max);
        }
        else
        {
            currentSum = 0;
            for (int i = 0; i < n; i++)
            {
                currentSum += matrix[i, i];
            }

            Console.WriteLine("NO " + currentSum);
        }
    }
}

