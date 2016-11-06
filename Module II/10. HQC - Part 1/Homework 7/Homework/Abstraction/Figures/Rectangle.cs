using System;
using Abstraction.Interfaces;

namespace Abstraction.Figures
{
    public class Rectangle : Figure, IRectangle
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
                    throw new ArgumentException("Width should be possiive");
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
                    throw new ArgumentException("Height should be possitive");
                }

                this.height = value;
            }
        }

        public override double CalaculateSurface()
        {
            return this.Width * this.Height;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (this.Width + this.Height);
        }
    }
}
