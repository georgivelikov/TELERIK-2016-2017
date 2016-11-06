using System;
using WalkInMatrix.Contracts;

namespace WalkInMatrix
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
