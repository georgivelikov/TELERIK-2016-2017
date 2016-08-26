namespace Task08
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int intervalInMilisecond = 1000;
            Timer timer = new Timer();
            timer.Changed += TicksChanged;
            timer.Tick(intervalInMilisecond);
        }

        private static void TicksChanged(object sender, CustomEvetArgs eventArgs)
        {
            Console.WriteLine(eventArgs.Ticks);
        }
    }
}
