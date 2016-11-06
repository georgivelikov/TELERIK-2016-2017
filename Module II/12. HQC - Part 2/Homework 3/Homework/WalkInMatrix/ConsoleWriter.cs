using System;
using WalkInMatrix.Contracts;

namespace WalkInMatrix
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
            Console.WriteLine(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
