namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Sortable_Collection.Contracts;

    public class InsertionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            this.InsertionSort(collection.ToList());
        }

        private void InsertionSort(List<T> collection)
        {
            for (int i = 1; i < collection.Count; i++)
            {
                int targetIndex = i - 1;

                while (collection[i].CompareTo(collection[targetIndex]) < 0)
                {
                    targetIndex--;
                    if (targetIndex == -1)
                    {
                        break;
                    }
                }

                if (targetIndex != -1)
                {
                    if (targetIndex < i - 1)
                    {
                        T item = collection[i];
                        collection.RemoveAt(i);
                        collection.Insert(targetIndex + 1, item);
                    }
                }
                else
                {
                    targetIndex = 0;
                    if (collection[i].CompareTo(collection[targetIndex]) < 0)
                    {
                        T item = collection[i];
                        collection.RemoveAt(i);
                        collection.Insert(targetIndex, item);
                    }
                }
                
            }
        }
    }
}
