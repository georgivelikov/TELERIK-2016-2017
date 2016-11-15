using System;
using System.Collections.Generic;
using Composite.Models;

namespace Composite
{
    public class StartUp
    {
        public static void Main()
        {
            var primeMinister = new Minister("Boyko Borisov");
            var deputyPrimeMinister = new Minister("Tomislav Donchev");
            var ministerOfInfrastucture = new Minister("Lilyana Pavlova");
            var ministerOfFinance = new Minister("Vladislav Goranov");
            var clerkOne = new Clerk("Georgi Georgiev");
            var clerkTwo = new Clerk("Ivan Ivanov");
            var clerkThree = new Clerk("Maria Georgieva");
            var clerkFour = new Clerk("Petar Petrov");
            var clerkFive = new Clerk("Hristo Hristov");

            primeMinister.AddSubordinate(deputyPrimeMinister);
            deputyPrimeMinister.AddSubordinate(ministerOfInfrastucture);
            deputyPrimeMinister.AddSubordinate(ministerOfFinance);
            ministerOfInfrastucture.AddSubordinate(clerkOne);
            ministerOfInfrastucture.AddSubordinate(clerkFive);
            ministerOfInfrastucture.AddSubordinate(clerkFour);
            ministerOfFinance.AddSubordinate(clerkTwo);
            ministerOfFinance.AddSubordinate(clerkThree);

            primeMinister.Display(0);

            Console.WriteLine("Just an useful example, no political attachments :D");
        }
    }
}
