using System;
using Abstraction.Interfaces;

namespace Abstraction.Figures
{
    public class Circle : Figure, ICircle
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

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Radius must be possitive");
                }
                this.radius = value;
            }
        }

        public override double CalaculateSurface()
        {
            return Math.PI * Math.Pow(this.Radius, 2);
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * this.Radius;
        }
    }
}
