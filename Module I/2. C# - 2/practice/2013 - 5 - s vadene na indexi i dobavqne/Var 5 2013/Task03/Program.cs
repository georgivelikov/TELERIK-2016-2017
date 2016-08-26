using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Configuration;
using System.Xml.Linq;

public class Program
{
    private static int rows = 0;
    private static int cols = 0;
    private static bool redDead = false;
    private static bool blueDead = false;
    private static bool[,] matrix;
    private static int redRow;
    private static int redCol;
    private static int blueRow;
    private static int blueCol;
    private static char redDir;
    private static char blueDir;
    private static int i = 0;
    private static int j = 0;
    private static int redDistance = 1;
    private static int blueDistance = 1;

    private static int x;
    private static int y;
    private static int z;

    public static void Main()
    {
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        x = arr[0];
        y = arr[1];
        z = arr[2];

        rows = x;
        cols = 2 * (z + y);
        matrix = new bool[rows, cols];

        redDead = false;
        blueDead = false;

        redRow = x / 2;
        redCol = z / 2;
        blueRow = x / 2;
        blueCol = redCol + y + y + z;

        int redStartRow = redRow;
        int redStartCol = redCol;

        redDir = 'R';
        blueDir = 'L';

        char[] redMoves = Console.ReadLine().ToCharArray();
        char[] blueMoves = Console.ReadLine().ToCharArray();
        i = 0;
        j = 0;

        while (true)
        {
            if (i < redMoves.Length && !redDead)
            {
                redDistance = 1;
                char c = redMoves[i];
                CalculateRedDistanceAndDirection(c);
                MoveRed();
            }

            if (j < blueMoves.Length && !blueDead)
            {
                blueDistance = 1;
                char c = blueMoves[j];
                CalculateBlueDistanceAndDirection(c);
                MoveBlue();
            }

            if (redDead)
            {
                break;
            }

            if (i == redMoves.Length - 1)
            {
                break;
            }

            i++;
            j++;
        }

        int finish = 0;
        if (redDead)
        {
            Console.WriteLine("BLUE");
        }
        else if (blueDead)
        {
            Console.WriteLine("RED");
        }
        else if (redDead && blueDead)
        {
            Console.WriteLine("DRAW");
        }
        finish = Math.Abs(redStartRow - redRow) + Math.Abs(redStartCol - redCol);

        Console.WriteLine(finish);
    }

    private static void CalculateRedDistanceAndDirection(char c)
    {
        if (Char.IsDigit(c))
        {
            i++;
            redDistance = c - 48;
        }
        else if (c == 'L')
        {
            if (redDir == 'L')
            {
                redDir = 'D';
            }
            else if (redDir == 'R')
            {
                redDir = 'U';
            }
            else if (redDir == 'D')
            {
                redDir = 'R';
            }
            else if (redDir == 'U')
            {
                redDir = 'L';
            }
        }
        else if (c == 'R')
        {
            if (redDir == 'L')
            {
                redDir = 'U';
            }
            else if (redDir == 'R')
            {
                redDir = 'D';
            }
            else if (redDir == 'D')
            {
                redDir = 'L';
            }
            else if (redDir == 'U')
            {
                redDir = 'R';
            }
        }
    }

    private static void MoveRed()
    {
        for (int k = 0; k < redDistance; k++)
        {
            if (redDir == 'L')
            {
                redCol--;
                if (redCol == -1)
                {
                    redCol = cols - 1;
                }
                if (!matrix[redRow, redCol])
                {
                    matrix[redRow, redCol] = true;
                }
                else
                {
                    if (!blueDead)
                    {
                        redDead = true;
                        return;
                    }
                }
            }
            else if (redDir == 'R')
            {
                redCol++;
                if (redCol == cols)
                {
                    redCol = 0;
                }

                if (!matrix[redRow, redCol])
                {
                    matrix[redRow, redCol] = true;
                }
                else
                {
                    if (!blueDead)
                    {
                        redDead = true;
                        return;
                    }
                }
            }
            else if (redDir == 'D')
            {
                redRow++;
                if (redRow >= rows)
                {
                    redRow = rows - 1;
                    if (redCol >= z && redCol < z + y)
                    {
                        if (!blueDead)
                        {
                            redDead = true;
                            return;
                        }
                    }
                }
                
                if (!matrix[redRow, redCol])
                {
                    matrix[redRow, redCol] = true;
                }
                else
                {
                    if (!blueDead)
                    {
                        redDead = true;
                        return;
                    }
                }
            }
            else if (redDir == 'U')
            {
                redRow--;
                if (redRow < 0)
                {
                    redRow = 0;
                    if (redCol >= z && redCol < z + y)
                    {
                        if (!blueDead)
                        {
                            redDead = true;
                            return;
                        }
                    }
                }

                if (!matrix[redRow, redCol])
                {
                    matrix[redRow, redCol] = true;
                }
                else
                {
                    if (!blueDead)
                    {
                        redDead = true;
                        return;
                    }
                }
            }
        }
    }

    private static void CalculateBlueDistanceAndDirection(char c)
    {
        if (Char.IsDigit(c))
        {
            j++;
            blueDistance = c - 48;
        }
        else if (c == 'L')
        {
            if (blueDir == 'L')
            {
                blueDir = 'D';
            }
            else if (blueDir == 'R')
            {
                blueDir = 'U';
            }
            else if (blueDir == 'D')
            {
                blueDir = 'R';
            }
            else if (blueDir == 'U')
            {
                blueDir = 'L';
            }
        }
        else if (c == 'R')
        {
            if (blueDir == 'L')
            {
                blueDir = 'U';
            }
            else if (blueDir == 'R')
            {
                blueDir = 'D';
            }
            else if (blueDir == 'D')
            {
                blueDir = 'L';
            }
            else if (blueDir == 'U')
            {
                blueDir = 'R';
            }
        }
    }

    private static void MoveBlue()
    {
        for (int k = 0; k < blueDistance; k++)
        {
            if (blueDir == 'L')
            {
                blueCol--;
                if (blueCol == -1)
                {
                    blueCol = cols - 1;
                }

                if (!matrix[blueRow, blueCol])
                {
                    matrix[blueRow, blueCol] = true;
                }
                else
                {
                    blueDead = true;
                    if (redCol == blueCol && blueRow == redRow)
                    {
                        redDead = true;
                    }

                    return;
                }
            }
            else if (blueDir == 'R')
            {
                blueCol++;
                if (blueCol == cols)
                {
                    blueCol = 0;
                }

                if (!matrix[blueRow, blueCol])
                {
                    matrix[blueRow, blueCol] = true;
                }
                else
                {
                    blueDead = true;
                    if (redCol == blueCol && blueRow == redRow)
                    {
                        redDead = true;
                    }

                    return;
                }
            }
            else if (blueDir == 'D')
            {
                blueRow++;
                if (blueRow >= rows)
                {
                    blueRow = rows - 1;
                    if (blueCol >= z && blueCol < z + y)
                    {
                        blueDead = true;
                        return;
                    }
                }

                if (!matrix[blueRow, blueCol])
                {
                    matrix[blueRow, blueCol] = true;
                }
                else
                {
                    blueDead = true;
                }
            }
            else if (blueDir == 'U')
            {
                blueRow--;
                if (blueRow < 0)
                {
                    blueRow = 0;
                    if (blueCol >= z && blueCol < z + y)
                    {
                        blueDead = true;
                        return;
                    }
                }

                if (!matrix[blueRow, blueCol])
                {
                    matrix[blueRow, blueCol] = true;
                }
                else
                {
                    blueDead = true;
                    return;
                }
            }
        }
    }
}

