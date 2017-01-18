using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    public class Program
    {
        public static void Main()
        {
            var collection1 = new List<string>() { "asdasd", "22", "Georgi", "Don4o", "vaaaa", "searchedValue", "ttt" };

            var searchedValue = "searchedValue";

            var linearSearcher = new LinearSearcher<string>();

            var searchedIndex = linearSearcher.Search(searchedValue, collection1);
            Console.WriteLine("Linear search result:");
            Console.WriteLine($"Index of searcher value with linear search is {searchedIndex}");
            Console.WriteLine();

            var collection2 = new List<int>() { 0, 2, 5, 6, 9, 1, 7, 4, 3, 8 };
            collection2.Sort();
            var binarySearcher = new BinarySearcher<int>();
            var searchedIndex2 = binarySearcher.Search(3, collection2);
            Console.WriteLine("Binary search result:");
            Console.WriteLine($"Index of searcher value with linear search is {searchedIndex2}");
            Console.WriteLine();

            var shuffler = new Shuffler<int>();
            var collection3 = new List<int>() { 2, 3, 1, 6, 2, 8, 9, 11, 222, 3 };
            Console.WriteLine("Collection: " + string.Join(" ", collection3));
            shuffler.Shuffle(collection3);
            Console.WriteLine("Collection after shuffling: " + string.Join(" ", collection3));
        }
    }
}
