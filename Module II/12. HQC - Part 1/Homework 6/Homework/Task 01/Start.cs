using System;

namespace Methods
{
    public class Start
    {
        public static void Main()
        {
            // Student examples:
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Student class examples:");
            Console.ResetColor();

            Student studentOne = new Student("Peter", "Ivanov", new DateTime(1992, 3, 17), "Sofia");
            Student studentTwo = new Student("Stella", "Markova", new DateTime(1993, 11, 3), "Vidin", "gamer");
            Console.WriteLine(studentOne);
            Console.WriteLine(studentTwo);
            if (studentOne.IsOlderThan(studentTwo))
            {
                Console.WriteLine("{0} is older than {1}", studentOne.FirstName, studentTwo.FirstName);
            }
            else
            {
                Console.WriteLine("{0} is older than {1}", studentOne.FirstName, studentTwo.FirstName);
            }

            // MathExtensions examples:
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nMathExtensions class examples:");
            Console.ResetColor();

            double triangleSideA = 4;
            double triangleSideB = 9;
            double triangleSideC = 12;
            Console.WriteLine(
                "Triangle with sides {0}, {1} and {2} has area {3:f2}",
                triangleSideA,
                triangleSideB,
                triangleSideC,
                MathExtensions.CalculateTriangleArea(triangleSideA, triangleSideB, triangleSideC));

            Console.WriteLine();
            double pointAx = 2;
            double pointAy = 3;
            double pointBx = 5;
            double pointBy = 4;
            Console.WriteLine(
                "Distance between point A with coordinates ({0} {1}) and point B with coordinates ({2} {3}) is {4:f2}",
                pointAx,
                pointAy,
                pointBx,
                pointBy,
                MathExtensions.CalculateDistance(pointAx, pointAy, pointBx, pointBy));

            // Number funtionalities examples:
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nNumberFunctionalities class examples:");
            Console.ResetColor();

            int number = 8;
            Console.WriteLine("Word representation of digit {0} is \"{1}\"", number, NumberFunctionalities.NumberToDigit(number));

            Console.WriteLine();
            int a = 2;
            int b = 3;
            int c = 5;
            int d = -2;
            Console.WriteLine(
                "The biggest number among {0}, {1}, {2} and {3} is {4}",
                a,
                b,
                c,
                d,
                NumberFunctionalities.FindMax(a, b, c, d));

            Console.WriteLine();
            float numberToFormat = 0.2f;

            string percentSymbol = "%";
            string floatSymbol = "f";
            string eightSpacesSymbol = "r";

            NumberFunctionalities.PrintAsNumber(numberToFormat, percentSymbol);
            NumberFunctionalities.PrintAsNumber(numberToFormat, floatSymbol);
            NumberFunctionalities.PrintAsNumber(numberToFormat, eightSpacesSymbol);
        }
    }
}
