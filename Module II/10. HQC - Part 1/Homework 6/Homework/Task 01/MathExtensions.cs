using System;

namespace Methods
{
    /// <summary>
    /// MathExtensions provides same useful mathematical functions
    /// </summary>
    public static class MathExtensions
    {
        public static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides should be positive!");
            }

            if (a + b <= c || a + c <= b || c + b <= a)
            {
                throw new ArgumentException("Sides should be able to form a triangle!");
            }

            double s = (a + b + c) / 2;

            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            
            return area;
        }

        public static double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));

            return distance;
        }
    }
}
