using System;
using System.Collections.Generic;

namespace SortingHomework
{
    public class QuickSorter<T> : ISorter<T> where T : IComparable
    {
        public IList<T> Sort(IList<T> collection)
        {
            this.QuickSort(collection, 0, collection.Count - 1);

            return collection;
        }

        private void QuickSort(IList<T> collection, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            T pivot = collection[start];
            int storeIndex = start + 1;

            for (int i = start + 1; i <= end; i++)
            {
                if (collection[i].CompareTo(pivot) < 0)
                {
                    this.Swap(collection, i, storeIndex);
                    storeIndex++;
                }
            }

            storeIndex--;
            this.Swap(collection, start, storeIndex);
            this.QuickSort(collection, start, storeIndex - 1);
            this.QuickSort(collection, storeIndex + 1, end);
        }

        private void Swap<T>(IList<T> collection, int first, int second)
        {
            T oldFirst = collection[first];
            collection[first] = collection[second];
            collection[second] = oldFirst;
        }
    }
}
