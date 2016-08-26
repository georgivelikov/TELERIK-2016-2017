namespace Task04
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var personOne = new Person("Ivan");
            var personTwo = new Person("Dragan", 19);

            Console.WriteLine(personOne);
            Console.WriteLine();
            Console.WriteLine(personTwo);
        }
    }
}
