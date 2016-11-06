using System;
using SchoolSystem.Contracts;

namespace SchoolSystem.Core
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
