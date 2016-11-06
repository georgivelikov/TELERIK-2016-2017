namespace Task_02
{
    public class Program
    {
        public static void Main()
        {
            var consoleWriter = new ConsoleWriter();
            var array = new double[] { 1, 2, 3.33, 4, 51.2222, -13, -0.11 };

            ArrayStatistics.PrintStatistics(array, consoleWriter);
        }
    }
}
