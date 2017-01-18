using System.Collections.Generic;

using NUnit.Framework;

namespace SortingHomework.Tests
{
    [TestFixture]
    public class Tests
    {
        [TestCase("SelectionSorter")]
        [TestCase("QuickSorter")]
        [TestCase("MergeSorter")]
        public void TestIfCollectionsIsSorted_WhenCollectionIsAverageNumbersCollection(string sorterType)
        {
            ISorter<int> sorter = null;
            switch (sorterType)
            {
                case "SelectionSorter": sorter = new SelectionSorter<int>();
                    break;
                case "MergeSorter":
                    sorter = new MergeSorter<int>();
                    break;
                case "QuickSorter":
                    sorter = new QuickSorter<int>();
                    break;
            }

            var collection = new List<int> { 33, 231, 321312, 22, 1, 1, 5, 6, 8 };
            var sortedCollection = new List<int>(sorter.Sort(collection));
            collection.Sort();

            CollectionAssert.AreEqual(sortedCollection, collection);
        }

        [TestCase("SelectionSorter")]
        [TestCase("QuickSorter")]
        [TestCase("MergeSorter")]
        public void TestIfCollectionsIsSorted_WhenCollectionHasManySameElementsAtTheEnds(string sorterType)
        {
            ISorter<int> sorter = null;
            switch (sorterType)
            {
                case "SelectionSorter":
                    sorter = new SelectionSorter<int>();
                    break;
                case "MergeSorter":
                    sorter = new MergeSorter<int>();
                    break;
                case "QuickSorter":
                    sorter = new QuickSorter<int>();
                    break;
            }

            var collection = new List<int> { 33, 231, 321312, 22, 1, 1, 5, 6, 8, 8, 8, 8, 8 };
            var sortedCollection = new List<int>(sorter.Sort(collection));
            collection.Sort();
            CollectionAssert.AreEqual(sortedCollection, collection);
        }

        [TestCase("SelectionSorter")]
        [TestCase("QuickSorter")]
        [TestCase("MergeSorter")]
        public void TestIfCollectionsIsSorted_WhenCollectionHasManySameElementsAtTheBeginning(string sorterType)
        {
            ISorter<int> sorter = null;
            switch (sorterType)
            {
                case "SelectionSorter":
                    sorter = new SelectionSorter<int>();
                    break;
                case "MergeSorter":
                    sorter = new MergeSorter<int>();
                    break;
                case "QuickSorter":
                    sorter = new QuickSorter<int>();
                    break;
            }

            var collection = new List<int> { 2, 2, 2, 2, 2, 2, 33, 231, 321312, 22, 1, 1, 5, 6, 8 };
            var sortedCollection = new List<int>(sorter.Sort(collection));
            collection.Sort();

            CollectionAssert.AreEqual(sortedCollection, collection);
        }

        [TestCase("SelectionSorter")]
        [TestCase("QuickSorter")]
        [TestCase("MergeSorter")]
        public void TestIfCollectionsIsSorted_WhenCollectionContainsStrings(string sorterType)
        {
            ISorter<string> sorter = null;
            switch (sorterType)
            {
                case "SelectionSorter":
                    sorter = new SelectionSorter<string>();
                    break;
                case "MergeSorter":
                    sorter = new MergeSorter<string>();
                    break;
                case "QuickSorter":
                    sorter = new QuickSorter<string>();
                    break;
            }

            var collection = new List<string> { "fsfsa", "aaasd", "asdfadfd", "zzzzzzzzz", "XASD", "222" };
            var sortedCollection = new List<string>(sorter.Sort(collection));
            collection.Sort();

            CollectionAssert.AreEqual(sortedCollection, collection);
        }
    }
}
