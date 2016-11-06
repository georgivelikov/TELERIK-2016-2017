using System;

namespace CohesionAndCoupling.Models
{
    public class Figure3D
    {
        private double width;
        private double height;
        private double depth;

        public Figure3D(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width should be positive");
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

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height should be positive");
                }

                this.height = value;
            }
        }

        public double Depth
        {
            get
            {
                return this.depth;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Depth should be positive");
                }

                this.depth = value;
            }
        }
    }
}
