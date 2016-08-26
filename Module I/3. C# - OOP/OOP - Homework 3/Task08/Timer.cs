namespace Task08
{
    using System;
    using System.Threading;

    using Task08;

    public delegate void ChangedEventHandler(object sender, CustomEvetArgs eventArgs);

    public class Timer
    {
        private int ticks = 0;

        public event ChangedEventHandler Changed;

        public void Tick(int intervalInMiliseconds)
        {
            while (true)
            {
                this.ticks++;
                this.OnChanged();
                Thread.Sleep(intervalInMiliseconds);
            }
        }

        private void OnChanged()
        {
            if (this.Changed != null)
            {
                this.Changed(this, new CustomEvetArgs(this.ticks));    
            }
        }
    }
}
