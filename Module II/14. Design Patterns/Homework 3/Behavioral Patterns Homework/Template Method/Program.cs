using System;

namespace Template_Method
{
    public class Program
    {
        public static void Main()
        {
            var wolf = new Wolf();
            var cow = new Cow();

            Console.WriteLine(wolf.Introduce());
            Console.WriteLine(cow.Introduce());
        }
    }
}
