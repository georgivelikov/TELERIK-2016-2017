using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpBracketsBetter
{
    class CSharpBracketsBetter
    {

        static void Main(string[] args)
        {
            int linesCount = int.Parse(Console.ReadLine());
            string indentationString = Console.ReadLine();

            List<string> lines = new List<string>(linesCount);
            StringBuilder resultToClean = new StringBuilder();
            StringBuilder indentation = new StringBuilder("");

            //int indentationsCount = 0;

            for (int i = 0; i < linesCount; i++)
            {
                string currLine = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(currLine))
                {
                    currLine = currLine.Trim();

                    bool isTrimming = true;

                    StringBuilder currResultLine = new StringBuilder("");

                    for (int currCharInd = 0; currCharInd < currLine.Length; currCharInd++)
                    {
                        char currChar = currLine[currCharInd];

                        if (!char.IsWhiteSpace(currChar))
                        {
                            isTrimming = false;
                        }

                        if (currChar == '{')
                        {
                            isTrimming = true;
                            if (currCharInd != 0/* && currLine[currCharInd - 1] != '{' && currLine[currCharInd - 1] != '}'*/)
                            {
                                resultToClean.Append("\r\n");
                                currResultLine = new StringBuilder("");
                            }
                            resultToClean.Append(indentation);
                            indentation.Append(indentationString);
                        }
                        else if (currChar == '}')
                        {
                            isTrimming = true;
                            indentation.Remove(indentation.Length - indentationString.Length, indentationString.Length);
                            if (currCharInd != 0/* && currLine[currCharInd - 1] != '{' && currLine[currCharInd - 1] != '}'*/)
                            {
                                resultToClean.Append("\r\n");
                                currResultLine = new StringBuilder("");
                            }
                            resultToClean.Append(indentation);
                        }
                        else if (currCharInd == 0)
                        {
                            resultToClean.Append(indentation);
                        }

                        if (!char.IsWhiteSpace(currChar) || (!isTrimming && currChar != currLine[currCharInd + 1]))
                        {
                            resultToClean.Append(currChar);
                        }

                        if (currCharInd == currLine.Length - 1)
                        {
                            resultToClean.Append("\r\n");
                            //result.Append(indentation);
                        }

                        if (currChar == '{' && currCharInd != currLine.Length - 1)
                        {
                            resultToClean.Append("\r\n");
                            //if (currLine[currCharInd + 1] != '}')
                            //{
                                resultToClean.Append(indentation);
                            //}
                        }

                        if (currChar == '}' && currCharInd != currLine.Length - 1)
                        {
                            resultToClean.Append("\r\n");
                            resultToClean.Append(indentation);
                        }
                    }
                }
            }

            string[] separators = new string[] { "\r\n" };

            string[] splitResult = resultToClean.ToString().Split(separators, StringSplitOptions.RemoveEmptyEntries);

            StringBuilder endResult = new StringBuilder(resultToClean.Length);
            int indentationsCount = 0;
            int cnt = 0;
            foreach (var line in splitResult)
            {
                if (line.Contains('{'))
                {
                    indentationsCount++;
                    endResult.AppendLine(line.Trim());
                }
                else if (line.Contains('}'))
                {
                    indentationsCount--;
                    endResult.AppendLine(line.Trim());
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(line.Substring(indentationsCount * indentationString.Length)))
                    {
                        endResult.AppendLine(line.Trim());
                    }
                }
                cnt++;
            }

            Console.Write(endResult.ToString());
        }
    }
}
/*
135
..
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stars
{
    class Program
    {
        static string[] separators = new string[] { " " };

        static int width;
        static int height;
        static int depth;

        static int[] letterStarCounts = new int[(int)('Z' - 'A'+ 1)];
        static int totalStarCount = 0;

        static void Main(string[] args)
        {
            char[, ,] cube = InputCube();

            CalculateStarCounts(cube);

            Console.WriteLine(totalStarCount);
            for (int i = 0; i < letterStarCounts.Length; i++)
            {
                if (letterStarCounts[i] != 0)
                {
                    Console.WriteLine("{0} {1}", (char)(i + 'A'), letterStarCounts[i]);
                }
            }
        }

        private static void CalculateStarCounts(char[, ,] cube)
        {
            for (int currHeight = 1; currHeight < height-1; currHeight++)
            {
                for (int currDepth = 1; currDepth < depth-1; currDepth++)
                {
                    for (int currWidth = 1; currWidth < width-1; currWidth++)
                    {
                        if (IsStar(cube, currWidth, currHeight, currDepth))
                        {
                            totalStarCount++;

                            char symbol = cube[currWidth, currHeight, currDepth];
                            letterStarCounts[(int)symbol - 'A']++;
                        }
                    }
                }
            }
        }

        private static bool IsStar(char[, ,] cube, int currWidth, int currHeight, int currDepth)
        {
            char center = cube[currWidth, currHeight, currDepth];
            if (center != cube[currWidth - 1, currHeight, currDepth])
            {
                return false;
            }

            if (center != cube[currWidth, currHeight - 1, currDepth])
            {
                return false;
            }

            if (center != cube[currWidth, currHeight + 1, currDepth])
            {
                return false;
            }

            if (center != cube[currWidth + 1, currHeight, currDepth])
            {
                return false;
            }

            if (center != cube[currWidth, currHeight, currDepth + 1])
            {
                return false;
            }

            if (center != cube[currWidth, currHeight, currDepth - 1])
            {
                return false;
            }

            return true;
        }

        private static void OutputCube(char[, ,] cube)
        {
            for (int currHeight = 0; currHeight < height; currHeight++)
            {
                for (int currDepth = 0; currDepth < depth; currDepth++)
                {
                    for (int currWidth = 0; currWidth < width; currWidth++)
                    {
                        Console.Write(cube[currWidth, currHeight, currDepth]);
                    }
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        private static char[,,] InputCube()
        {
            string[] dimensions = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);

            width = int.Parse(dimensions[0]);
            height = int.Parse(dimensions[1]);
            depth = int.Parse(dimensions[2]);


            char[,,] cube = new char[width, height, depth];

            for (int currHeight = 0; currHeight < height; currHeight++)
            {
                string[] rows = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);

                for (int currDepth = 0; currDepth < depth; currDepth++)
                {
                    string currRow = rows[currDepth];
                    for (int currWidth = 0; currWidth < width; currWidth++)
                    {
                        cube[currWidth, currHeight, currDepth] = currRow[currWidth];
                    }
                }
            }

            return cube;
        }
    }
}
*/
/*
2
..
{ a()  ){sa}{dsdas}}{!{{adasds{a}}
}{}}
 */