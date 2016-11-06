using System;

namespace Task_02
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }

        public void Write(string line)
        {
            Console.Write(line);
        }
    }
}
