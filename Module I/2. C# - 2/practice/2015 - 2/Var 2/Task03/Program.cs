namespace Task03
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class Program
    {
        public static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            BigInteger[,] matrix = new BigInteger[rows, cols];
            bool[,] visited = new bool[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    double pow = rows - 1 - i + j;
                    matrix[i, j] = (BigInteger)Math.Pow(2, pow);
                    visited[i, j] = false;
                }
            }

            int numberOfCodes = int.Parse(Console.ReadLine()); // ?
            decimal[] codes = Console.ReadLine().Split().Select(x => decimal.Parse(x)).ToArray();

            int coef = Math.Max(rows, cols);

            BigInteger sum = 0;
            int currentRow = rows - 1;
            int currentCol = 0;

            for (int i = 0; i < numberOfCodes; i++)
            {
                int targetRow = (int)codes[i] / coef;

                if (targetRow >= rows)
                {
                    targetRow = rows - 1;
                }

                int targetCol = (int)codes[i] % coef;

                if (targetCol >= cols)
                {
                    targetCol = cols - 1;
                }

                if (currentCol < targetCol)
                {
                    while (currentCol <= targetCol)
                    {
                        if (!visited[currentRow, currentCol])
                        {
                            sum += matrix[currentRow, currentCol];
                            visited[currentRow, currentCol] = true;
                        }

                        currentCol++;
                    }

                    currentCol--;

                }
                else if (currentCol > targetCol)
                {
                    while (currentCol >= targetCol)
                    {
                        if (!visited[currentRow, currentCol])
                        {
                            sum += matrix[currentRow, currentCol];
                            visited[currentRow, currentCol] = true;
                        }

                        currentCol--;
                    }

                    currentCol++;
                }
                else
                {
                    if (!visited[currentRow, currentCol])
                    {
                        sum += matrix[currentRow, currentCol];
                        visited[currentRow, currentCol] = true;
                    }
                }

                if (currentRow < targetRow)
                {
                    while (currentRow <= targetRow)
                    {
                        if (!visited[currentRow, currentCol])
                        {
                            sum += matrix[currentRow, currentCol];
                            visited[currentRow, currentCol] = true;
                        }

                        currentRow++;
                    }

                    currentRow--;

                }
                else if (currentRow > targetRow)
                {
                    while (currentRow >= targetRow)
                    {
                        if (!visited[currentRow, currentCol])
                        {
                            sum += matrix[currentRow, currentCol];
                            visited[currentRow, currentCol] = true;
                        }

                        currentRow--;
                    }

                    currentRow++;
                }
                else
                {
                    if (!visited[currentRow, currentCol])
                    {
                        sum += matrix[currentRow, currentCol];
                        visited[currentRow, currentCol] = true;
                    }
                }
            }

            Console.WriteLine(sum);
        }

        private static void Print(BigInteger[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
