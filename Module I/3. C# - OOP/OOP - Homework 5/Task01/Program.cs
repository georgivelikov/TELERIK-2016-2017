namespace Task01
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var rectangle = new Rectangle(5, 6);
            var triangle = new Triangle(3, 2);
            var square = new Square(4);

            var list = new List<Shape>();
            list.Add(rectangle);
            list.Add(triangle);
            list.Add(square);

            foreach (var shape in list)
            {
                Console.WriteLine(shape.GetType().Name + ":" + shape.CalculateSurface());
            }
        }
    }
}
