using System;

namespace Dealership.Engine
{
    public class ConsoleInputOutputProvider : IInputOutputProvider
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
