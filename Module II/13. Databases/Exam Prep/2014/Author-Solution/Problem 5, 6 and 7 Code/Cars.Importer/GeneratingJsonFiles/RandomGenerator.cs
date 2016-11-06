namespace Cars.Importer.GeneratingJsonFiles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RandomGenerator : IRandomGenerator
    {
        private const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        private static RandomGenerator instance;

        private readonly Random random;

        private RandomGenerator()
        {
            this.random = new Random();
        }

        public static RandomGenerator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RandomGenerator();
                }

                return instance;
            }
        }

        public int GetRandomNumber(int min, int max)
        {
            return this.random.Next(min, max + 1);
        }

        public string GetRandomString(int length)
        {
            var chars = new char[length];

            for (int i = 0; i < length; i++)
            {
                chars[i] = Letters[this.GetRandomNumber(0, Letters.Length - 1)];
            }

            return new string(chars);
        }

        public IEnumerable<string> GetRandomStrings(int count, int length)
        {
            var list = new List<string>(count);
            for (int i = 0; i < count; i++)
            {
                list.Add(this.GetRandomString(length));
            }

            return list;
        }

        public T GetRandomElement<T>(IList<T> collection)
        {
            var count = collection.Count();
            return collection[this.GetRandomNumber(0, count - 1)];
        }
    }
}
