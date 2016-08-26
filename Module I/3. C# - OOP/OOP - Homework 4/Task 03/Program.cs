namespace Task_03
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            Dog dog = new Dog("Sharo", 5, Sex.Male);
            Frog frog = new Frog("Jaba", 3, Sex.Male);
            Cat cat = new Cat("Milko", 17, Sex.Male);
            Kitten kitten = new Kitten("Slavka", 3);
            Tomcat tomcat = new Tomcat("Ivan", 2);

            Console.WriteLine("Dog:");
            dog.Sound();
            Console.WriteLine("Frog:");
            frog.Sound();
            Console.WriteLine("Cat:");
            cat.Sound();
            Console.WriteLine("Kitten:");
            kitten.Sound();
            Console.WriteLine("Tomcat:");
            tomcat.Sound();

            Console.WriteLine();

            List<Animal> list = new List<Animal> { dog, frog, cat, kitten, tomcat };
            var averageAge = list.Average(a => a.Age);
            Console.WriteLine("Average age: " + averageAge);



        }
    }
}
