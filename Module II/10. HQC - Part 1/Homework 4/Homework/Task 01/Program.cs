using System;

namespace Task_01
{
    public class Program
    {
        public static void Main()
        {
            var rectangle = new Rectangle(5, 10);
            var rotatedRectangle = rectangle.GenerateRotatedRectangle(60);
            Console.WriteLine(rotatedRectangle);
        }
    }
}
