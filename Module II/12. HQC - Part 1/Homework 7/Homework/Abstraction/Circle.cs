using System;

namespace Abstraction
{
    public class Circle : Figure
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Radius must be positive");
                }

                this.radius = value;
            }
        }

        public override double CalculateSurface()
        {
            return Math.PI * this.Radius * this.Radius;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * this.Radius;
        }

        public override string ToString()
        {
            return string.Format(
                "I am a circle. My perimeter is {0:f2}. My surface is {1:f2}.",
                this.CalculatePerimeter(),
                this.CalculateSurface());
        }
    }
}
