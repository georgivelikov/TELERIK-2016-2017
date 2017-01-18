using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMP
{
    // dfa = deterministic finite-state automaton
    public class Program
    {
        private static int counter = 0;
        private static int finalCounter = 0;
        public static void Main()
        {
            string mainPattern = Console.ReadLine();
            string text = Console.ReadLine();

            if(mainPattern.Length == 1)
            {
                for (int i = 0; i < text.Length; i++)
                {
                    if(text[i] == mainPattern[0])
                    {
                        counter++;
                    }
                }

                Console.WriteLine(counter);
                return;
            }

            for (int i = 1; i < mainPattern.Length; i++)
            {
                string pattern1 = mainPattern.Substring(0, i);
                string pattern2 = mainPattern.Substring(i, mainPattern.Length - i);

                var c1 = 0;
                var c2 = 0;

                if (pattern1.Length == 1)
                {
                    for (int j = 0; j < text.Length; j++)
                    {
                        if (text[j] == pattern1[0])
                        {
                            counter++;
                        }
                    }
                }
                else
                {
                    var kmp1 = new KMP(pattern1);

                    int startIndex1 = 0;
                    while (true)
                    {
                        startIndex1 = kmp1.Search(text, startIndex1);
                        if (startIndex1 == -1)
                        {
                            break;
                        }
                    }
                }
                c1 = counter;
                counter = 0;

                if (pattern2.Length == 1)
                {
                    for (int j = 0; j < text.Length; j++)
                    {
                        if (text[j] == pattern2[0])
                        {
                            counter++;
                        }
                    }
                }
                else
                {
                    var kmp2 = new KMP(pattern2);

                    int startIndex2 = 0;
                    while (true)
                    {
                        startIndex2 = kmp2.Search(text, startIndex2);
                        if (startIndex2 == -1)
                        {
                            break;
                        }
                    }
                }
                c2 = counter;
                counter = 0;
                finalCounter += c1 * c2;               
            }

            counter = 0;
            var kmp = new KMP(mainPattern);

            int startIndex = 0;
            while (true)
            {
                startIndex = kmp.Search(text, startIndex);
                if (startIndex == -1)
                {
                    break;
                }
            }

            Console.WriteLine(finalCounter + counter);
        }

        public class KMP
        {
            private string pattern;
            private int[,] dfa;

            public KMP(string pattern)
            {
                this.pattern = pattern;
                int m = this.pattern.Length;
                int r = 256;
                this.dfa = new int[r, m];
                this.dfa[this.pattern[0], 0] = 1;

                for (int x = 0, j = 1; j < m; j++)
                {
                    for (int c = 0; c < r; c++)
                    {
                        dfa[c, j] = dfa[c, x]; // copy mismatch cases
                    }
                    dfa[this.pattern[j], j] = j + 1; // set match case
                    x = dfa[this.pattern[j], x]; // update restart state
                }
            }

            public int Search(string text, int startIndex) // could be int - the index where found
            {
                int n = text.Length;
                int m = pattern.Length;
                int i, j;

                for (i = startIndex, j = 0; i < n && j < m; i++)
                {
                    j = dfa[text[i], j];
                }

                if (j == m)
                {
                    counter++; // found, hit end of pattern
                    // return i - m; // return index where pattern starts
                    //Console.WriteLine(i - m);
                    return i - 1; // return where pattern ends
                }
                else
                {
                    return -1;//not found, hit end of text
                }
            }
        }
    }
}
