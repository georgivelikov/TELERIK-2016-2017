using System;
using System.Collections.Generic;

namespace Task02
{
    public class Program
    {
        public static void Main()
        {
            var set = new HashSet<string>();

            string[] arr = { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

            for (int i = 0; i < arr.Length; i++)
            {
                if (set.Contains(arr[i]))
                {
                    set.Remove(arr[i]);
                }
                else
                {
                    set.Add(arr[i]);
                }
            }

            Console.WriteLine(string.Join(", ", set));
        }
    }
}
