using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laser
{
    class Laser
    {
        static int cubeWidth, cubeHeight, cubeDepth;

        static void Main(string[] args)
        {
            string[] cubeDimensions = Console.ReadLine().Split();

            cubeWidth = int.Parse(cubeDimensions[0]);
            cubeHeight = int.Parse(cubeDimensions[1]);
            cubeDepth = int.Parse(cubeDimensions[2]);

            bool[,,] burnedCubes = new bool[cubeWidth, cubeHeight, cubeDepth];

            string[] startCoords = Console.ReadLine().Split();

            int posW = int.Parse(startCoords[0]), 
                posH = int.Parse(startCoords[1]), 
                posD = int.Parse(startCoords[2]);

            string[] directionComponents = Console.ReadLine().Split();

            int dirW = int.Parse(directionComponents[0]), 
                dirH = int.Parse(directionComponents[1]), 
                dirD = int.Parse(directionComponents[2]);

            while (true)
            {
                burnedCubes[posW - 1, posH - 1, posD - 1] = true;

                UpdateDirection(posW, posH, posD, ref dirW, ref dirH, ref dirD);

                int nextW = posW + dirW,
                    nextH = posH + dirH,
                    nextD = posD + dirD;

                if (burnedCubes[nextW - 1, nextH - 1, nextD - 1] || IsOnEdge(nextW, nextH, nextD))
                {
                    break;
                }
                else
                {
                    posW = nextW;
                    posH = nextH;
                    posD = nextD;
                }
            }

            Console.WriteLine("{0} {1} {2}", posW, posH, posD);
        }

        private static void UpdateDirection(int posW, int posH, int posD, ref int dirW, ref int dirH, ref int dirD)
        {
            int nextW = posW + dirW,
                nextH = posH + dirH,
                nextD = posD + dirD;

            if (IsOutsideWidth(nextW))
            {
                dirW *= -1;
            }
            if (IsOutsideHeight(nextH))
            {
                dirH *= -1;
            }
            if (IsOutsideDepth(nextD))
            {
                dirD *= -1;
            }
        }

        private static bool IsOutside(int posW, int posH, int posD)
        {
            return IsOutsideWidth(posW) ||
                IsOutsideHeight(posH) ||
                IsOutsideDepth(posD);
        }

        private static bool IsOutsideWidth(int posW)
        {
            return posW < 1 || posW > cubeWidth;
        }

        private static bool IsOutsideHeight(int posH)
        {
            return (posH < 1 || posH > cubeHeight);
        }

        private static bool IsOutsideDepth(int posD)
        {
            return (posD < 1 || posD > cubeDepth);
        }

        private static bool IsOnEdge(int posW, int posH, int posD)
        {
            //bottom edges (H == 1)
            if (posH == 1)
            {
                //blue
                if (posD == 1 || posD == cubeDepth)
                {
                    return true;
                }
                //red
                if (posW == 1 || posW == cubeWidth)
                {
                    return true;
                }
            }
            //...
            //top edges (H == cubeH)
            else if (posH == cubeHeight)
            {
                //blue
                if (posD == 1 || posD == cubeDepth)
                {
                    return true;
                }
                //red
                if (posW == 1 || posW == cubeWidth)
                {
                    return true;
                }
            }
            //side edges (H is different)
            else
            {
                //near left
                if (posD == 1 && posW == 1)
                {
                    return true;
                }
                //near right
                if (posD == 1 && posW == cubeWidth)
                {
                    return true;
                }
                //far left
                if (posD == cubeDepth && posW == 1)
                {
                    return true;
                }
                //far right
                if (posD == cubeDepth && posW == cubeWidth)
                {
                    return true;
                }

            }

            return false;
        }
    }
}
/*
5 10 5
2 1 3
1 0 1
*/