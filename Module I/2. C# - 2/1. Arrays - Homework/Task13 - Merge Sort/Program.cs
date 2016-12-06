using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task13___Merge_Sort
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            MergeSort(arr, 0, arr.Length - 1);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        private static void MergeSort<T>(T[] array, int start, int end) where T : IComparable
        {
            if (start < end)
            {
                int middle = start + (end - start) / 2;
                MergeSort(array, start, middle);
                MergeSort(array, middle + 1, end);

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
