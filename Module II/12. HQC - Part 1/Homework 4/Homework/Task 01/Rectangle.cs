using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_01
{
    public class Rectangle
    {
        private readonly double width;
        private readonly double height;

        public Rectangle(double width, double height)
        {
            this.ValidateInputWidth(width);
            this.ValidateInputHeight(height);
            this.width = width;
            this.height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
        }

        public Rectangle GenerateRotatedRectangle(double rotationAngle)
        {
            var newWidth = Math.Abs(Math.Sin(rotationAngle) * this.width) + Math.Abs(Math.Cos(rotationAngle) * this.height);
            var newHeight = Math.Abs(Math.Cos(rotationAngle) * this.width) + Math.Abs(Math.Sin(rotationAngle) * this.height);

            var rotatedRectangle = new Rectangle(newWidth, newHeight);

            return rotatedRectangle;
        }

        public override string ToString()
        {
            return string.Format("Width: {0:0.00}, Height: {1:0.00}", this.width, this.height);
        }

        private void ValidateInputWidth(double width)
        {
            if (width <= 0)
            {
                throw new ArgumentException("Width must be possitive");
            }
        }

        private void ValidateInputHeight(double height)
        {
            if (height <= 0)
            {
                throw new ArgumentException("Height must be possitive");
            }
        }
    }
}
