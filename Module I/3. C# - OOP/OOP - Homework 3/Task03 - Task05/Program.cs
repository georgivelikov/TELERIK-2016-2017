namespace Task03___Task05
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var s1 = new Student("Ivan", "Qnkov", 22);
            var s2 = new Student("Petar", "Ivanov", 27);
            var s3 = new Student("Maria", "Todorova", 18);
            var s4 = new Student("Boris", "Petrov", 25);
            var s5 = new Student("Maria", "Asenova", 31);
            var s6 = new Student("Hristo", "Angelov", 31);

            List<Student> list = new List<Student> { s1, s2, s3, s4, s5, s6 };

            // Task 03
            var firstBeforeLast = list.Where(s => string.Compare(s.FisrtName, s.LastName, StringComparison.Ordinal) < 1);
            Console.WriteLine("Fisrt name before last name: " + string.Join(", ", firstBeforeLast));

            // Task 04
            var ageRange = list.Where(s => s.Age >= 18 && s.Age <= 24);
            Console.WriteLine("Age between 18 and 24: " + string.Join(", ", ageRange));
            
            // Task 05
            var sortedStudents = list.OrderByDescending(s => s.FisrtName).ThenByDescending(s => s.LastName); // LINQ
            Console.WriteLine("Sorted list: " + string.Join(", ", sortedStudents));
        }
    }
}
