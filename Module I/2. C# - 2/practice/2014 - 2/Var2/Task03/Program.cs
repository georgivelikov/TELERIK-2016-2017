using System;
using System.Collections.Generic;

public class Program
{
    private static int [,] matrix;
 
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int sum = 0;
        matrix = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            string[] arr = Console.ReadLine().Split();
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = int.Parse(arr[j]);
            }
        }

        for (int i = 0; i < n - 2; i++)
        {
            for (int j = 0; j < n - 1; j++)
            {
                int current = matrix[i, j];
                bool currentDigit = false;
                switch (current)
                {
                    case 0:
                        currentDigit = CheckForZero(i, j);
                        break;
                    case 1:
                        currentDigit = CheckForOne(i, j);
                        break;
                    case 2:
                        currentDigit = CheckForTwo(i, j);
                        break;
                    case 3:
                        currentDigit = CheckForThree(i, j);
                        break;
                    case 4:
                        currentDigit = CheckForFour(i, j);
                        break;
                    case 5:
                        currentDigit = CheckForFive(i, j);
                        break;
                    case 6:
                        currentDigit = CheckForSix(i, j);
                        break;
                    case 7:
                        currentDigit = CheckForSeven(i, j);
                        break;
                    case 8:
                        currentDigit = CheckForEight(i, j);
                        break;
                    case 9:
                        currentDigit = CheckForNine(i, j);
                        break;
                    default: break;
                }

                if (currentDigit)
                {
                    sum += current;
                }
                
            }

        }
        Console.WriteLine(sum);
    }

    private static bool CheckForZero(int row, int col)
    {
        try
        {
            if (matrix[row, col + 1] == 0
                && matrix[row, col + 2] == 0
                && matrix[row + 1, col] == 0
                && matrix[row + 2, col] == 0
                && matrix[row + 3, col] == 0
                && matrix[row + 4, col] == 0
                && matrix[row + 1, col + 2] == 0
                && matrix[row + 2, col + 2] == 0
                && matrix[row + 3, col + 2] == 0
                && matrix[row + 4, col + 2] == 0
                && matrix[row + 4, col + 1] == 0
            )
        {
            return true;
        }
        else
        {
            return false;
        }
        }
        catch (Exception)
        {
            return false;
        }
    }

    private static bool CheckForOne(int row, int col)
    {
        try
        {
            if (matrix[row - 1, col + 1] == 1
                && matrix[row - 2, col + 2] == 1
                && matrix[row - 1, col + 2] == 1
                && matrix[row, col + 2] == 1
                && matrix[row + 1, col + 2] == 1
                && matrix[row + 2, col + 2] == 1
            )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    }

    private static bool CheckForTwo(int row, int col)
    {
        try
        {
            if (matrix[row - 1, col + 1] == 2
                && matrix[row, col + 2] == 2
                && matrix[row + 1, col + 2] == 2
                && matrix[row + 2, col + 1] == 2
                && matrix[row + 3, col] == 2
                && matrix[row + 3, col + 1] == 2
                && matrix[row + 3, col + 2] == 2
            )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    }

    private static bool CheckForThree(int row, int col)
    {
        try
        {
            if (matrix[row, col + 1] == 3
                && matrix[row, col + 2] == 3
                && matrix[row + 1, col + 2] == 3
                && matrix[row + 2, col + 1] == 3
                && matrix[row + 2, col + 2] == 3
                && matrix[row + 3, col + 2] == 3
                && matrix[row + 4, col] == 3
                && matrix[row + 4, col + 1] == 3
                && matrix[row + 4, col + 2] == 3
            )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    }

    private static bool CheckForFour(int row, int col)
    {
        try
        {
            if (matrix[row, col + 2] == 4
                && matrix[row + 1, col] == 4
                && matrix[row + 1, col + 2] == 4
                && matrix[row + 2, col] == 4
                && matrix[row + 2, col + 1] == 4
                && matrix[row + 2, col + 2] == 4
                && matrix[row + 3, col + 2] == 4
                && matrix[row + 4, col + 2] == 4
            )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    }

    private static bool CheckForFive(int row, int col)
    {
        try
        {
            if (matrix[row, col + 1] == 5
                && matrix[row, col + 2] == 5
                && matrix[row + 1, col] == 5
                && matrix[row + 2, col] == 5
                && matrix[row + 2, col + 1] == 5
                && matrix[row + 2, col + 2] == 5
                && matrix[row + 3, col + 2] == 5
                && matrix[row + 4, col] == 5
                && matrix[row + 4, col + 1] == 5
                && matrix[row + 4, col + 2] == 5
            )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    }

    private static bool CheckForSix(int row, int col)
    {
        try
        {
            if (matrix[row, col + 1] == 6
                && matrix[row, col + 2] == 6
                && matrix[row + 1, col] == 6
                && matrix[row + 2, col] == 6
                && matrix[row + 2, col + 1] == 6
                && matrix[row + 2, col + 2] == 6
                && matrix[row + 3, col] == 6
                && matrix[row + 3, col + 2] == 6
                && matrix[row + 4, col] == 6
                && matrix[row + 4, col + 1] == 6
                && matrix[row + 4, col + 2] == 6
            )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    }

    private static bool CheckForSeven(int row, int col)
    {
        try
        {
            if (matrix[row, col + 1] == 7
                && matrix[row, col + 2] == 7
                && matrix[row + 1, col + 2] == 7
                && matrix[row + 2, col + 1] == 7
                && matrix[row + 3, col + 1] == 7
                && matrix[row + 4, col + 1] == 7
            )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    }

    private static bool CheckForEight(int row, int col)
    {
        try
        {
            if (matrix[row, col + 1] == 8
                && matrix[row, col + 2] == 8
                && matrix[row + 1, col] == 8
                && matrix[row + 1, col + 2] == 8
                && matrix[row + 2, col + 1] == 8
                && matrix[row + 3, col] == 8
                && matrix[row + 3, col + 2] == 8
                && matrix[row + 4, col] == 8
                && matrix[row + 4, col + 1] == 8
                && matrix[row + 4, col + 2] == 8
            )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    }

    private static bool CheckForNine(int row, int col)
    {
        try
        {
            if (matrix[row, col + 1] == 9
                && matrix[row, col + 2] == 9
                && matrix[row + 1, col] == 9
                && matrix[row + 1, col + 2] == 9
                && matrix[row + 2, col + 1] == 9
                && matrix[row + 2, col + 2] == 9
                && matrix[row + 3, col + 2] == 9
                && matrix[row + 4, col] == 9
                && matrix[row + 4, col + 1] == 9
                && matrix[row + 4, col + 2] == 9
            )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    }
}

