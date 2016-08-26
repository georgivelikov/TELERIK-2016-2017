using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTML
{
    class Program
    {
        const string revTagOpen = "<rev>";
        const string upperTagOpen = "<upper>";
        const string lowerTagOpen = "<lower>";
        const string toggleTagOpen = "<toggle>";
        const string delTagOpen = "<del>";

        const string revTagClose = "</rev>";
        const string upperTagClose = "</upper>";
        const string lowerTagClose = "</lower>";
        const string toggleTagClose = "</toggle>";
        const string delTagClose = "</del>";

        static List<string> currentOpenedTags = new List<string>();
        static List<int> revTagContentStarts = new List<int>();
        static int openedDelTags = 0;


        static string GetTag(string s, int searchStartInd)
        {
            int tagStart = 0;
            if (s[searchStartInd] == '<')
            {
                tagStart = searchStartInd;
            }

            int tagLast = s.IndexOf('>', tagStart + 1);

            string tag = s.Substring(tagStart, tagLast - tagStart + 1);

            return tag;
        }

        static bool IsClosing(string tag)
        {
            return tag[1] == '/';
        }

        static void Reverse(StringBuilder sb, int first, int lastInclusive)
        {
            int leftInd = first,
                rightInd = lastInclusive;

            while (leftInd < rightInd)
            {
                char leftBuffer = sb[leftInd];
                sb[leftInd] = sb[rightInd];
                sb[rightInd] = leftBuffer;

                leftInd++;
                rightInd--;
            }
        }

        static char GetAppliedTagEffect(char symbol, string tag)
        {
            char resultSymbol = symbol;
            if (Char.IsLetter(resultSymbol))
            {
                switch (tag)
                {
                    case lowerTagOpen: resultSymbol = Char.ToLower(symbol); break;
                    case upperTagOpen: resultSymbol = Char.ToUpper(symbol); break;

                    case toggleTagOpen:
                        if (Char.IsLower(symbol))
                        {
                            resultSymbol = Char.ToUpper(symbol);
                        }
                        else
                        {
                            resultSymbol = Char.ToLower(symbol);
                        }
                        break;
                }
            }
            return resultSymbol;
        }

        private static void ProcessTag(StringBuilder result, string tag)
        {
            if (tag == delTagOpen)
            {
                openedDelTags++;
            }
            else if (tag == delTagClose)
            {
                openedDelTags--;
            }
            else
            {
                if (openedDelTags == 0)
                {
                    if (tag == revTagOpen)
                    {
                        revTagContentStarts.Add(result.Length);
                    }
                    else if (tag == revTagClose)
                    {
                        int currentRevContentStart = revTagContentStarts[revTagContentStarts.Count - 1];
                        Reverse(result, currentRevContentStart, result.Length - 1);
                        RemoveLastRevTagContentStart();
                    }
                    else if (IsClosing(tag))
                    {
                        RemoveLastCurrentWrappingTag();
                    }
                    else
                    {
                        currentOpenedTags.Add(tag);
                    }
                }
            }
        }

        static void RemoveLastRevTagContentStart()
        {
            revTagContentStarts.RemoveAt(revTagContentStarts.Count - 1);
        }

        static void RemoveLastCurrentWrappingTag()
        {
            currentOpenedTags.RemoveAt(currentOpenedTags.Count - 1);
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                string currLine = Console.ReadLine();

                int inputSymbolInd = 0;
                while (inputSymbolInd < currLine.Length)
                {
                    if (currLine[inputSymbolInd] == '<')
                    {
                        string tag = GetTag(currLine, inputSymbolInd);

                        ProcessTag(result, tag);

                        int tagLastInd = inputSymbolInd + tag.Length - 1;
                        inputSymbolInd = tagLastInd;
                    }
                    else
                    {
                        if (openedDelTags == 0)
                        {
                            char symbolToAdd = currLine[inputSymbolInd];
                            for (int tagInd = currentOpenedTags.Count - 1; tagInd >= 0; tagInd--)
                            {
                                symbolToAdd = GetAppliedTagEffect(symbolToAdd, currentOpenedTags[tagInd]);
                            }

                            result.Append(symbolToAdd);
                        }
                    }

                    inputSymbolInd++;
                }

                result.Append("\n");
            }

            result.Replace("\n", Environment.NewLine);

            Console.Write(result.ToString());
        }
    }
}
/*
1
<del><rev><rev>here</rev></rev><del>nothing</del>still nothing</del><upper><del>nothing</del><rev>emos</rev><del>some</del>thing</upper>
*/
/*
3
<del><rev></rev></del><upper>Shalalalalalalalalallalalalalalallallalalalalalala</upper>
sha
lala
/*
1
<rev>All right everyone, line up alphabetically according to your height</rev>
*/
/*
1
<rev>My fake plants died because I did not pretend to water them.</rev>
*/