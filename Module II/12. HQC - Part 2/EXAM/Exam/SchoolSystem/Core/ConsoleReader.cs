using System;
using SchoolSystem.Contracts;

namespace SchoolSystem.Core
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}