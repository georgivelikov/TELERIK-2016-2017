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

        public static void Main()
        {
            // mostly working
            // not working when pattern length == 1!
            string pattern = "ab";
            string text = "abcasabcjkkabiiabcabckdalkdaabc";

            var kmp = new KMP(pattern);

            int startIndex = 0;
            while (true)
            {
                startIndex = kmp.Search(text, startIndex);
                if (startIndex == -1)
                {
                    break;
                }
            }


            Console.WriteLine(counter);
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
                    return i - 1; // return where pattern ends - 1
                }
                else
                {
                    return -1;//not found, hit end of text
                }
            }
        }
    }
}
