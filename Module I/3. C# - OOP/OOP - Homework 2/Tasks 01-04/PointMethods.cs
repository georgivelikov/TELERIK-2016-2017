namespace Tasks_01_04
{
    using System;

    public static class PointMethods
    {
        public static double CalculateDistance(Point p1, Point p2)
        {
            double result =
                Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2) + Math.Pow(p1.Z - p2.Z, 2));

            return Math.Abs(result);
        }
    }
}
