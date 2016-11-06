using SchoolSystem.Core;

namespace SchoolSystem
{
    public class StartUp
    {
        public static void Main()
        {
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();
            var data = new SchoolSystemData();
            var engine = new Engine(reader, writer, data);
            engine.Run();
        }
    }
}
