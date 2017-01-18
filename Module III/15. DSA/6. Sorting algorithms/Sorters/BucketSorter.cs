namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Sortable_Collection.Contracts;

    public class BucketSorter : ISorter<int>
    {
        public double Max { get; set; }

        public void Sort(List<int> collection)
        {
            this.BucketSort(collection);
        }

        private void BucketSort(List<int> collection)
        {
            var buckets = new List<int>[collection.Count];

            foreach (var element in collection)
            {
                int bucketIndex = (int)(element / this.Max * collection.Count);

                if (buckets[bucketIndex] == null)
                {
                    buckets[bucketIndex] = new List<int>();
                }

                buckets[bucketIndex].Add(element);
            }

            var sorter = new Quicksorter<int>();

            for (int i = 0; i < buckets.Length; i++)
            {
                if (buckets[i] != null)
                {
                    sorter.Sort(buckets[i]);
                }
            }

            int index = 0;
            foreach (var bucket in buckets)
            {
                if (bucket == null)
                {
                    continue;
                }

                foreach (var item in bucket)
                {
                    collection[index] = item;
                    index++;
                }
            }
        }
    }
}
