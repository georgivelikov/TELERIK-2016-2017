using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_03_Sorting_Algorithms
{
    // Algorithms are taken from GitHub and other sources
    public static class SortingAlgoritms
    {
        //Selection sort
        public static int[] SelectionSort(int[] array)
        {
            for (int pos = 0; pos < array.Length; pos++)
            {
                int minIdx = FindMin(array, pos);
                Swap(array, pos, minIdx);
            }
            return array;
        }

        private static void Swap<T>(T[] arr, int pos, int minIdx)
        {
            T hold = arr[pos];
            arr[pos] = arr[minIdx];
            arr[minIdx] = hold;
        }

        private static int FindMin<T>(T[] arr, int pos) where T : IComparable<T>
        {
            int minIdx = pos;
            for (int i = pos + 1; i < arr.Length; i++)
            {
                if (arr[i].CompareTo(arr[minIdx]) < 0)
                {
                    minIdx = i;
                }
            }
            return minIdx;
        }

        //Insertion sort
        public static int[] InsertionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int j = i + 1;

                while (j > 0)
                {
                    if (array[j - 1] > array[j])
                    {
                        int temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;

                    }
                    j--;
                }
            }
            return array;
        }

        public static int[] QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
            return array;
        }
        //Quick sort
        public static void QuickSort(int[] array, int left, int right)
        {
            int i = left, j = right;
            int pivot = array[(left + right) / 2];

            while (i <= j)
            {
                while (array[i] < pivot)
                {
                    i++;
                }

                while (array[j] > pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    int tmp = array[i];
                    array[i] = array[j];
                    array[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                QuickSort(array, left, j);
            }

            if (i < right)
            {
                QuickSort(array, i, right);
            }
        }

        //Merge sort
        public static int[] MergeSort(int[] array)
        {
            // If list size is 0 (empty) or 1, consider it sorted and return it
            // (using less than or equal prevents infinite recursion for a zero length array).
            if (array.Length <= 1)
            {
                return array;
            }
        
            // Else list size is > 1, so split the list into two sublists.
            int middleIndex = array.Length / 2;
            int[] left = new int[middleIndex];
            int[] right = new int[array.Length - middleIndex];

            Array.Copy(array, left, middleIndex);
            Array.Copy(array, middleIndex, right, 0, right.Length);

            // Recursively call MergeSort() to further split each sublist
            // until sublist size is 1.
            left = MergeSort(left);
            right = MergeSort(right);

            // Merge the sublists returned from prior calls to MergeSort()
            // and return the resulting merged sublist.
            return Merge(left, right);
        }

        private static int[] Merge(int[] left, int[] right)
        {
            // Convert the input arrays to lists, which gives more flexibility 
            // and the option to resize the arrays dynamically.
            List<int> leftList = left.OfType<int>().ToList();
            List<int> rightList = right.OfType<int>().ToList();
            List<int> resultList = new List<int>();

            // While the sublist are not empty merge them repeatedly to produce new sublists 
            // until there is only 1 sublist remaining. This will be the sorted list.
            while (leftList.Count > 0 || rightList.Count > 0)
            {
                if (leftList.Count > 0 && rightList.Count > 0)
                {
                    // Compare the 2 lists, append the smaller element to the result list
                    // and remove it from the original list.
                    if (leftList[0] <= rightList[0])
                    {
                        resultList.Add(leftList[0]);
                        leftList.RemoveAt(0);
                    }

                    else
                    {
                        resultList.Add(rightList[0]);
                        rightList.RemoveAt(0);
                    }
                }

                else if (leftList.Count > 0)
                {
                    resultList.Add(leftList[0]);
                    leftList.RemoveAt(0);
                }

                else if (rightList.Count > 0)
                {
                    resultList.Add(rightList[0]);
                    rightList.RemoveAt(0);
                }
            }

            // Convert the resulting list back to a static array
            int[] result = resultList.ToArray();
            return result;
        }
    }
}
