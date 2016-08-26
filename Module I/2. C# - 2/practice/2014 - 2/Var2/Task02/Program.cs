using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

public class Program
{
    public static void Main()
    {
        long[] arr = Console.ReadLine().Split().Select(x => long.Parse(x)).ToArray();
        int len = arr.Length;
        int positionMolly = 0;
        int positionDolly = len - 1;
        BigInteger sumMolly = 0;
        BigInteger sumDolly = 0;

        sumMolly = arr[positionMolly];
        sumDolly = arr[positionDolly];

        long fMolly = arr[positionMolly];
        long fDolly = arr[positionDolly];

        bool gameOver = false;
        bool mollyOver = false;
        bool dollyOver = false;

        if (arr[positionMolly] == 0)
        {
            gameOver = true;
            mollyOver = true;
        }

        if (arr[positionDolly] == 0)
        {
            gameOver = true;
            dollyOver = true;
        }

        arr[positionMolly] = 0;
        arr[positionDolly] = 0;

        while (!gameOver)
        {
            positionMolly = positionMolly + (int)(fMolly % len);
            if (positionMolly >= len)
            {
                positionMolly -= len;
            }

            positionDolly = positionDolly - (int)(fDolly % len);
            if (positionDolly < 0)
            {
                positionDolly += len;
            }

            if (arr[positionMolly] == 0)
            {
                mollyOver = true;
                gameOver = true;
            }
            if (arr[positionDolly] == 0)
            {
                dollyOver = true;
                gameOver = true;
            }

            if (positionMolly != positionDolly)
            {
                sumMolly += arr[positionMolly];
                sumDolly += arr[positionDolly];
                fMolly = arr[positionMolly];
                fDolly = arr[positionDolly];
                arr[positionMolly] = 0;
                arr[positionDolly] = 0;
            }
            else
            {
                if (arr[positionDolly] % 2 != 0)
                {
                    long sum = arr[positionDolly] / 2;
                    sumMolly += sum;
                    sumDolly += sum;
                    fMolly = arr[positionMolly];
                    fDolly = arr[positionDolly];
                    arr[positionDolly] = 1;
                }
                else
                {
                    long sum = arr[positionDolly] / 2;
                    sumMolly += sum;
                    sumDolly += sum;
                    fMolly = arr[positionMolly];
                    fDolly = arr[positionDolly];
                    arr[positionDolly] = 0;
                }
            }

            if (gameOver)
            {
                break;
            }
        }

        if (mollyOver && !dollyOver)
        {
            Console.WriteLine("Dolly");
            Console.WriteLine("{0} {1}", sumMolly, sumDolly);
        }
        else if (!mollyOver && dollyOver)
        {
            Console.WriteLine("Molly");
            Console.WriteLine("{0} {1}", sumMolly, sumDolly);
        }
        else
        {
            Console.WriteLine("Draw");
            Console.WriteLine("{0} {1}", sumMolly, sumDolly);
        }

    }
}

