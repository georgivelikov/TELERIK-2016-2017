using System;
using System.Collections.Generic;

namespace SortingHomework
{
    public class SelectionSorter<T> : ISorter<T> where T : IComparable
    {
        public IList<T> Sort(IList<T> collection)
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                T current = collection[i];
                int minKey = i;

                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[j].CompareTo(collection[minKey]) < 0)
                    {
                        minKey = j;
                    }
                }

                this.Swap(minKey, i, collection);
            }

            return collection;
        }

        private void Swap(int indexOne, int indexTwo, IList<T> collection)
        {
            var temp = collection[indexOne];
            collection[indexOne] = collection[indexTwo];
            collection[indexTwo] = temp;
        }
    }
}
