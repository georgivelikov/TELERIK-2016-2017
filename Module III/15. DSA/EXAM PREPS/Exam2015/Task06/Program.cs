namespace Search
{
    using System;
    using System.Security.Policy;

    class StartUp
    {
        static void Main()
        {
            int counter = 0;

            string pattern = Console.ReadLine();
            string text = Console.ReadLine();
            int n = text.Length;
            int m = pattern.Length;

            if (m > n)
            {
                return;
            }

            // precompute

            int[] fl = new int[m + 1];
            fl[0] = -1;

            for (int i = 1; i < m; i++)
            {
                int j = fl[i];
                while (j >= 0 && pattern[j] != pattern[i])
                {
                    j = fl[j];
                }
                fl[i + 1] = j + 1;
            }

            // search

            int matched = 0;
            for (int i = 0; i < n; i++)
            {
                while (matched >= 0 && text[i] != pattern[matched])
                {
                    matched = fl[matched];
                }

                matched++;

                if (matched == m)
                {
                    counter++;
                    matched = fl[matched];
                }
            }

            for (int k = 1; k < pattern.Length; k++)
            {
                string patternOne = pattern.Substring(0, k);
                string patternTwo = pattern.Substring(k, pattern.Length - k);

                int firstCounter = 0;
                int secondCounter = 0;

                int m1 = patternOne.Length;
                int m2 = patternTwo.Length;

                int[] fl1 = new int[m1 + 1];
                fl1[0] = -1;

                for (int i = 1; i < m1; i++)
                {
                    int j = fl1[i];
                    while (j >= 0 && patternOne[j] != patternOne[i])
                    {
                        j = fl1[j];
                    }

                    fl1[i + 1] = j + 1;
                }

                // search

                int matched1 = 0;
                for (int i = 0; i < n; i++)
                {
                    while (matched1 >= 0 && text[i] != patternOne[matched1])
                    {
                        matched1 = fl1[matched1];
                    }

                    matched1++;

                    if (matched1 == m1)
                    {
                        firstCounter++;
                        matched1 = fl1[matched1];
                    }
                }

                int[] fl2 = new int[m2 + 1];
                fl2[0] = -1;

                for (int i = 1; i < m2; i++)
                {
                    int j = fl2[i];
                    while (j >= 0 && patternTwo[j] != patternTwo[i])
                    {
                        j = fl2[j];
                    }

                    fl2[i + 1] = j + 1;
                }

                // search

                int matched2 = 0;
                for (int i = 0; i < n; i++)
                {
                    while (matched2 >= 0 && text[i] != patternTwo[matched2])
                    {
                        matched2 = fl2[matched2];
                    }

                    matched2++;

                    if (matched2 == m2)
                    {
                        secondCounter++;
                        matched2 = fl2[matched2];
                    }
                }

                counter += firstCounter * secondCounter;

                firstCounter = 0;
                secondCounter = 0;
            }

            Console.WriteLine(counter);
        }
    }
}
