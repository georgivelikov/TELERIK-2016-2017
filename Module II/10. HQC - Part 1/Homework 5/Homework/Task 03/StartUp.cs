using System;
using System.Linq;

namespace Task_03
{
    public class StartUp
    {
        public static void Main()
        {
            int arrayLength = 1000;
            int[] array = Enumerable.Range(0, arrayLength).ToArray();
            int searchedValue = 666;


            for (int i = 0; i < arrayLength; i++)
            {
                if (array[i] % 10 == 0)
                {
                    Console.WriteLine(array[i]);
                }

                if (array[i] == searchedValue)
                {
                    Console.WriteLine("Heavy metal kopele");
                    break;
                }
            }
        }
    }
}
