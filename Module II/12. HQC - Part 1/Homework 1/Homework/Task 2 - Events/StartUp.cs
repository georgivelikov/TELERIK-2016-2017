using Task_2___Events;
using Task_2___Events.Engine;
using Task_2___Events.Interfaces;
using Task_2___Events.Utils;

public class StartUp
{
    public static void Main()
    {
        IReader consoleReader = new ConsoleReader();
        IWriter consoleWriter = new ConsoleWriter();

        var engine = new EventsEngine(consoleWriter, consoleReader);

        engine.Run();

        //see Events-Example-Input.txt for example input
    }
}