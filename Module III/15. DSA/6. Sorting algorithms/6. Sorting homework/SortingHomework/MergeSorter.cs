using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingHomework
{
    public class MergeSorter<T> : ISorter<T> where T : IComparable
    {
        public IList<T> Sort(IList<T> collection)
        {
            T[] array = collection.ToArray();
            this.MergeSort(array, 0, array.Length - 1);
            for (int i = 0; i < array.Length; i++)
            {
                collection[i] = array[i];
            }

            return collection;
        }

        private void MergeSort(T[] array, int start, int end)
        {
            if (start < end)
            {
                int middle = start + (end - start) / 2;

                this.MergeSort(array, start, middle);
                this.MergeSort(array, middle + 1, end);

                T[] temp = new T[end - start + 1];
                int leftMinIndex = start;
                int rightMinIndex = middle + 1;
                int tempIndex = 0;

                while (leftMinIndex <= middle && rightMinIndex <= end)
                {
                    if (array[leftMinIndex].CompareTo(array[rightMinIndex]) <= 0)
                    {
                        temp[tempIndex] = array[leftMinIndex];
                        leftMinIndex++;
                    }
                    else
                    {
                        temp[tempIndex] = array[rightMinIndex];
                        rightMinIndex++;
                    }

                    tempIndex++;
                }

                while (leftMinIndex <= middle)
                {
                    temp[tempIndex] = array[leftMinIndex];
                    leftMinIndex++;
                    tempIndex++;
                }

                while (rightMinIndex <= end)
                {
                    temp[tempIndex] = array[rightMinIndex];
                    rightMinIndex++;
                    tempIndex++;
                }

                Array.Copy(temp, 0, array, start, temp.Length);
            }
        }
    }
}
