using System;
using CohesionAndCoupling.FileUtilities;
using CohesionAndCoupling.GeometryUtilities;
using CohesionAndCoupling.Models;

namespace CohesionAndCoupling
{
    class UtilsExamples
    {
        static void Main()
        {
            //Console.WriteLine(FileUtils.GetFileExtension("example")); // throws exeption
            Console.WriteLine(FileUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileExtension("example.new.pdf"));
                                    
            //Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example")); // throws exeption
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                Geometry2DUtils.CalculateDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                Geometry3DUtils.CalculateDistance3D(5, 2, -1, 3, -6, 4));

            double width = 3;
            double height = 4;
            double depth = 5;
            Figure3D figure = new Figure3D(width, height, depth);

            Console.WriteLine("Volume = {0:f2}", Geometry3DUtils.CalculateVolume(figure));
            Console.WriteLine("Diagonal XYZ = {0:f2}", Geometry3DUtils.CalculateDiagonalXYZ(figure));
            Console.WriteLine("Diagonal XY = {0:f2}", Geometry3DUtils.CalculateDiagonalXY(figure));
            Console.WriteLine("Diagonal XZ = {0:f2}", Geometry3DUtils.CalculateDiagonalXZ(figure));
            Console.WriteLine("Diagonal YZ = {0:f2}", Geometry3DUtils.CalculateDiagonalYZ(figure));
        }
    }
}
