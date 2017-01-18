using System;
using System.Collections.Generic;

namespace Task01
{
    public class Shuffler<T> where T : IComparable
    {
        public void Shuffle(IList<T> collection)
        {
            Random rnd = new Random();
            var n = collection.Count;
            for (var i = 0; i < n; i++)
            {
                // Exchange array[i] with random element in array[i … n-1]
                int r = i + rnd.Next(0, n - i);
                var temp = collection[i];
                collection[i] = collection[r];
                collection[r] = temp;
            }
        }
    }
}
