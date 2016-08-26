namespace MobilePhones.Objects
{
    using System;
    using System.Text;

    public class Display
    {
        private const double DefaultSize = 7;
        private const int DefaultColors = 16000000;
        private const int Interval = 4;

        private double size;
        private int numberOfColours;

        public Display(double size)
            : this(size, DefaultColors)
        {
        }

        public Display(int numberOfColors)
            : this(DefaultSize, numberOfColors)
        {
        }

        public Display(double size, int numberOfColors)
        {
            this.Size = size;
            this.NumberOfColors = numberOfColors;
        }

        public double Size
        {
            get
            {
                return this.size;
            }

            set
            {
                if (value >= 3 && value <= 12)
                {
                    this.size = value;
                }
                else
                {
                    throw new ArgumentException("Please enter valid display size!");
                }
            }
        }

        public int NumberOfColors
        {
            get
            {
                return this.numberOfColours;
            }

            set
            {
                if (value < 2)
                {
                    throw new ArgumentException("Display must have at least 2 colors!");
                }

                this.numberOfColours = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Display Information:" + Environment.NewLine);
            sb.AppendFormat(new string(' ', Interval) + "Size: {0} inches" + Environment.NewLine, this.Size);
            sb.AppendFormat(new string(' ', Interval) + "Number of Colors: {0}" + Environment.NewLine, this.NumberOfColors);
            return sb.ToString();
        }
    }
}
