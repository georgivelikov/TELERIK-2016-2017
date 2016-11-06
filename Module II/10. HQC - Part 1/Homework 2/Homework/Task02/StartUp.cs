using System;

using Task02;

public class StartUp
{
    public static void Main()
    {
        var personFactory = new PersonFactory();

        var man = personFactory.CreatePerson("Pesho", 20);

        var woman = personFactory.CreatePerson("Maria", 19);

        Console.WriteLine(man);
        Console.WriteLine(woman);
    }
}