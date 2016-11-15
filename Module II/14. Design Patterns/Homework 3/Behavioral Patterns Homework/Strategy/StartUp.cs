namespace Strategy
{
    public class StartUp
    {
        public static void Main()
        {
            var consoleWriter = new ConsoleWriter();
            var fileWriter = new FileWriter();

            string line1 = "strategy1";
            string line2 = "strategy2";

            WriteText(consoleWriter, line1);
            WriteText(fileWriter, line2);
        }

        public static void WriteText(IWriter writer, string line)
        {
            writer.WriteLine(line);
        }
    }
}
