namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Sortable_Collection.Contracts;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            T[] array = collection.ToArray();
            this.MergeSort(array, 0, array.Length - 1);
            for (int i = 0; i < array.Length; i++)
            {
                collection[i] = array[i];
            }
        }

        private void MergeSort(T[] array, int start, int end)
        {
            //if (start == end)
            //{
            //    return;
            //}

            if (start < end)
            {
                int middle = start + (end - start) / 2;
                //T[] tempFirstHalf;
                //T[] tempSecondHalf;

                //tempFirstHalf = new T[middle + 1];
                //tempSecondHalf = new T[end - middle - 1];
                
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
