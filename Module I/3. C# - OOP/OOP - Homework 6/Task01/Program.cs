namespace Task01
{
    using System;
    using System.Collections.Generic;

    using Task01.Enumerations;

    public class Program
    {
        public static void Main()
        {
            Student s1 = new Student(
                "Ivan", 
                "Georgiev", 
                "Petrov",
                31231412,
                "Sofia ul.1",
                "0885 342 123",
                "ivan@abv.bg",
                3,
                Speciality.Accounting,
                Faculty.Financial,
                University.UNWE);
            Student s2 = new Student(
                "Petar",
                "Dobrev",
                "Petrov",
                4444444,
                "Sofia ul.2",
                "0885 342 223",
                "petar@abv.bg",
                2,
                Speciality.CommerceLaw,
                Faculty.Legal,
                University.SofiaUniversity);
            Student s3 = new Student(
                "Petar",
                "Dobrev",
                "Petrov",
                4444444,
                "Sofia ul.2",
                "0885 342 223",
                "petar@abv.bg",
                2,
                Speciality.CommerceLaw,
                Faculty.Legal,
                University.SofiaUniversity);
            Student s4 = new Student(
                "Milena",
                "Georgieva",
                "Petrova",
                3231231,
                "Sofia ul.3",
                "0885 342 223",
                "petar@abv.bg",
                2,
                Speciality.ComputerScience,
                Faculty.FMI,
                University.SofiaUniversity);
            Student s5 = new Student(
                "Petar",
                "Dobrev",
                "Petrov",
                111111,
                "Sofia ul.2",
                "0885 342 223",
                "petar@abv.bg",
                2,
                Speciality.CommerceLaw,
                Faculty.Legal,
                University.SofiaUniversity);

            // To String()
            Console.WriteLine("Task 01");
            Console.WriteLine("ToString():" + s1.ToString());

            // Equals()
            Console.WriteLine("Equals():" + s2.Equals(s3)); // expected true

            // GetHashCode()
            Console.WriteLine("GetHashCode():" + s2.GetHashCode());

            // ==
            Console.WriteLine(string.Format("== : {0}", s2 == s3)); // expected true

            // !=
            Console.WriteLine(string.Format("!= : {0}", s2 != s3)); // expected false

            // Task 02
            Console.WriteLine("\nTask 02");
            var newStudent = s1.Clone() as Student;
            Console.WriteLine(newStudent);
            s1.University = University.SofiaUniversity;
            Console.WriteLine();
            Console.WriteLine(newStudent); // works

            // Task 03 - works
            Console.WriteLine("\nTask 03");
            var list = new List<Student> { s1, s2, s3, s4, s5 };
            list.Sort();
            foreach (var student in list)
            {
                Console.WriteLine(student);
                Console.WriteLine();
            }
        }
    }
}
