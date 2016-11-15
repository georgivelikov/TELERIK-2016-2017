using System;

namespace Prototype
{
    public class StartUp
    {
        public static void Main()
        {
            var rabbitFather = new Rabbit("Black");
            var rabbitSon = rabbitFather.Multiply();

            rabbitSon.Color = "white";

            Console.WriteLine(rabbitFather);
            Console.WriteLine(rabbitSon);
        }
    }
}
