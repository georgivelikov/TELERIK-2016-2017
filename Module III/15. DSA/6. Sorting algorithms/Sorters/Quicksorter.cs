namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            this.QuickSort(collection, 0, collection.Count - 1);
        }

        private void QuickSort(List<T> collection, int start, int end)
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

        private void Swap<T>(List<T> collection, int first, int second)
        {
            T oldFirst = collection[first];
            collection[first] = collection[second];
            collection[second] = oldFirst;
        }
    }
}
