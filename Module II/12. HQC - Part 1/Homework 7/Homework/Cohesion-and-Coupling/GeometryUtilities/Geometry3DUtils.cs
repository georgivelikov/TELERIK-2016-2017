using System;
using CohesionAndCoupling.Models;

namespace CohesionAndCoupling.GeometryUtilities
{
    public static class Geometry3DUtils
    {
        public static double CalculateDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));
            return distance;
        }

        public static double CalculateVolume(Figure3D figure)
        {
            double volume = figure.Width * figure.Height * figure.Depth;
            return volume;
        }

        public static double CalculateDiagonalXY(Figure3D figure)
        {
            double distance = Geometry2DUtils.CalculateDistance2D(figure.Width, 0, 0, figure.Height);
            return distance;
        }

        public static double CalculateDiagonalXZ(Figure3D figure)
        {
            double distance = Geometry2DUtils.CalculateDistance2D(figure.Width, 0, 0, figure.Depth);
            return distance;
        }

        public static double CalculateDiagonalYZ(Figure3D figure)
        {
            double distance = Geometry2DUtils.CalculateDistance2D(figure.Height, 0, 0, figure.Depth);
            return distance;
        }

        public static double CalculateDiagonalXYZ(Figure3D figure)
        {
            double distance = CalculateDistance3D(0, 0, 0, figure.Width, figure.Height, figure.Depth);
            return distance;
        }
    }
}
