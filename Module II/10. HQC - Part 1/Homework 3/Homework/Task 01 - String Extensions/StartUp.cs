using System;

namespace Task_01___String_Extensions
{
    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            Console.WriteLine(string.Join(" ", StringExtensions.ToMD5Hash(input)));
        }
    }
}
