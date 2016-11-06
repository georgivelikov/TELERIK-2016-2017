using System;

namespace Abstraction
{
    public class Rectangle : Figure
    {
        private double width;

        private double height;

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width must be positive");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height must be positive");
                }

                this.height = value;
            }
        }

        public override double CalculateSurface()
        {
            return this.Width * this.Height;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (this.Width + this.Height);
        }

        public override string ToString()
        {
            return string.Format(
                "I am a rectangle. My perimeter is {0:f2}. My surface is {1:f2}.",
                this.CalculatePerimeter(),
                this.CalculateSurface());
        }
    }
}
