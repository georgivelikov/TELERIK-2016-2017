namespace Task07
{
    public delegate void SimpleDelegate(int interval);

    public class Program
    {
        public static void Main()
        {
            int intervalInMiliseconds = 1000;

            Timer timer = new Timer();
            // timer.Tick(intervalInMiliseconds);

            SimpleDelegate d = timer.Tick;
            d(intervalInMiliseconds);
        }
    }
}
