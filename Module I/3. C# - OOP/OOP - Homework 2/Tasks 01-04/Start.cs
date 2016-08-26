namespace Tasks_01_04
{
    using System;

    public class Start
    {
        public static void Main()
        {
            Point a = new Point(0, 2, 4);
            Point b = new Point(1.2332323232, 3.6, 14);
            Point c = new Point(-12, -2, 8.3);

            Console.WriteLine("A: " + a);
            Console.WriteLine("B: " + b);
            Console.WriteLine("C: " + c);
            Console.WriteLine("Zero Point: " + Point.ZeroPoint);

            Console.WriteLine();
            Console.WriteLine("Path between A and B: ");
            Console.WriteLine("{0:0.00}", PointMethods.CalculateDistance(a, b));

            Path path = new Path();
            path.AddPoint(a);
            path.AddPoint(b);
            path.AddPoint(c);

            // see OOP-Homework 2/save.txt for results, you can delete save.txt to see the results again on next start of the program
            string destination = "../../../save.txt";
            PathStorage.SavePath(destination, path);

            Console.WriteLine();
            string source = "../../../load.txt";
            Path loadedPath = PathStorage.LoatPath(source);
            Console.WriteLine("Points in path, loaded from file:");
            foreach (var point in loadedPath.Points)
            {
                Console.WriteLine(point);
            }
        }
    }
}
