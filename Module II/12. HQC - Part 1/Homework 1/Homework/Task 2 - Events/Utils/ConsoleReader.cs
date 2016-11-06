using System;

using Task_2___Events.Interfaces;

namespace Task_2___Events.Utils
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
