namespace Task_05
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var bitArray1 = new BitArray64(5);
            Console.WriteLine(bitArray1);
            Console.WriteLine(bitArray1.GetHashCode());

            var bitArray2 = new BitArray64(5);
            Console.WriteLine(bitArray2.GetHashCode());
            Console.WriteLine(bitArray1.Equals(bitArray2));

            Console.WriteLine("foreach cycle:");
            foreach (var num in bitArray1)
            {
                Console.Write(num);
            }

            Console.WriteLine();
            Console.WriteLine("indexer:");
            Console.WriteLine("bit at index 63:" + bitArray1[bitArray1.Lenght - 1]);
        }
    }
}
