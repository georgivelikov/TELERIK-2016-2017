using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    public class BinarySearcher<T> : ISearcher<T>
        where T : IComparable
    {
        public int Search(T value, IList<T> collection)
        {
            return this.BinarySearch(value, 0, collection.Count - 1, collection);
        }

        public int BinarySearch(T value, int startIndex, int endIndex, IList<T> collection)
        {
            if (endIndex < startIndex)
            {
                return -1;
            }

            else
            {
                int midPoint = startIndex + (endIndex - startIndex) / 2;

                if (collection[midPoint].CompareTo(value) > 0)
                {
                    return this.BinarySearch(value, startIndex, midPoint - 1, collection);
                }
                else if (collection[midPoint].CompareTo(value) < 0)
                {
                    return this.BinarySearch(value, midPoint + 1, endIndex, collection);
                }
                else
                {
                    return midPoint;
                }
            }
        }
    }
}
