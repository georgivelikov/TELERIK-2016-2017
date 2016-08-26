namespace Task07
{
    using System;
    using System.Threading;

    public class Timer
    {
        private int ticks = 0;

        public void Tick(int intervalInMiliseconds)
        {
            while (true)
            {
                this.ticks++;
                Console.WriteLine(this.ticks);
                Thread.Sleep(intervalInMiliseconds);
            }
        }
    }
}
