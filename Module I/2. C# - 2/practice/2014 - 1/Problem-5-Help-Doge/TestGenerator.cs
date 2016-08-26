namespace TestGenerator
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    internal class Program
    {
        private const string FileNameFormat = "test.{0:000}.in.txt";

        // n, m (1...1000), fx (0...n-1), fy (0...m-1), k (0...10000)
        private static readonly List<Tuple<int, int, int, int, int>> Tests = new List<Tuple<int, int, int, int, int>>
                                                         {
                                                             ////       n    m   fx   fy    k
                                                             new Tuple<int, int, int, int, int>(1, 1, 0, 0, 0), // 1
                                                             new Tuple<int, int, int, int, int>(5, 6, 4, 5, 2), // 2
                                                             new Tuple<int, int, int, int, int>(8, 8, 6, 7, 4), // 3
                                                             new Tuple<int, int, int, int, int>(10, 16, 9, 15, 10), // 4
                                                             new Tuple<int, int, int, int, int>(20, 28, 12, 13, 2), // 5
                                                             new Tuple<int, int, int, int, int>(38, 58, 37, 57, 100), // 6
                                                             new Tuple<int, int, int, int, int>(40, 40, 39, 37, 10), // 7
                                                             new Tuple<int, int, int, int, int>(80, 90, 79, 84, 6000), // 8
                                                             new Tuple<int, int, int, int, int>(100, 100, 37, 57, 100), // 9
                                                             new Tuple<int, int, int, int, int>(200, 300, 37, 57, 7000), // 10
                                                             new Tuple<int, int, int, int, int>(300, 58, 299, 57, 100), // 11
                                                             new Tuple<int, int, int, int, int>(400, 400, 37, 57, 10000), // 12
                                                             new Tuple<int, int, int, int, int>(450, 450, 446, 449, 0), // 13
                                                             new Tuple<int, int, int, int, int>(500, 500, 499, 489, 10), // 14
                                                             new Tuple<int, int, int, int, int>(500, 500, 9, 18, 9000), // 15
                                                             new Tuple<int, int, int, int, int>(500, 500, 499, 57, 50), // 16
                                                             new Tuple<int, int, int, int, int>(500, 500, 123, 489, 100), // 17
                                                             new Tuple<int, int, int, int, int>(500, 500, 467, 478, 1337), // 18
                                                             new Tuple<int, int, int, int, int>(500, 500, 499, 499, 6), // 19
                                                             new Tuple<int, int, int, int, int>(500, 500, 499, 499, 10000), // 20
                                                         };

        private static void Main()
        {
            var rand = new Random();
            for (var i = 1; i <= Tests.Count; i++)
            {
                var test = Tests[i - 1];
                var fileName = string.Format(FileNameFormat, i);
                using (var sw = new StreamWriter(fileName))
                {
                    sw.WriteLine("{0} {1}", test.Item1, test.Item2);
                    sw.WriteLine("{0} {1}", test.Item3, test.Item4);
                    sw.WriteLine("{0}", test.Item5);
                    for (int j = 0; j < test.Item5; j++)
                    {
                        int enemyX;
                        int enemyY;
                        do
                        {
                            enemyX = rand.Next(0, test.Item1);
                            enemyY = rand.Next(0, test.Item2);
                        }
                        while ((enemyX == 0 && enemyY == 0) || (enemyX == test.Item3 && enemyY == test.Item4));

                        sw.WriteLine("{0} {1}", enemyX, enemyY);
                    }
                }
            }
        }
    }
}
