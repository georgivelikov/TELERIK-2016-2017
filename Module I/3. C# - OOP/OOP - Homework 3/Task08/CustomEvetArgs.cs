namespace Task08
{
    using System;

    public class CustomEvetArgs : EventArgs
    {
        public CustomEvetArgs(int ticks)
        {
            this.Ticks = ticks;
        }

        public int Ticks { get; set; }
    }
}
