namespace Tasks09___15
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            Student s1 = new Student(
                "Ivan",
                "Petrov",
                112206,
                "02/11111111",
                "ivan@abv.bg",
                new List<int>() { 2, 2, 4, 5, 6 },
                2);
            Student s2 = new Student(
                "Georgi",
                "Georgiev",
                132205,
                "042/323211",
                "georgi@gmail.com",
                new List<int>() { 2, 6, 4, 5, 6 },
                3);
            Student s3 = new Student(
                "Maria",
                "Todorova",
                113206,
                "052/123245",
                "maria@abv.bg",
                new List<int>() { 2, 3, 4, 3, 5 },
                2);
            Student s4 = new Student(
                "Petya",
                "Petrova",
                412203,
                "02/123451",
                "petya@gmail.com",
                new List<int>() { 2, 3, 4, 6, 6 },
                1);
            Student s5 = new Student(
                "Staman",
                "Gospodinov",
                612206,
                "02/123451",
                "stamba@gmail.com",
                new List<int>() { 6, 5, 4, 6, 6 },
                4);
            Student s6 = new Student(
                "Pencho",
                "Dimitrov",
                612205,
                "022/923451",
                "bomba@gmail.com",
                new List<int>() { 2, 2, 3, 5, 3 },
                4);
            Student s7 = new Student(
                "Slavcho",
                "Toshev",
                612206,
                "022/923451",
                "sexy@abv.bg",
                new List<int>() { 4, 5, 4, 5, 5 },
                3);
            Student s8 = new Student(
                "Antonia",
                "Petrova",
                512204,
                "032/923111",
                "antonia@gmail.com",
                new List<int>() { 4, 3, 6, 5, 6 },
                1);

            List<Student> list = new List<Student>() { s1, s2, s3, s4, s5, s6, s7, s8 };

            // Task 09
            var studentsFromGroupTwo = list.Where(s => s.GroupNumber == 2).OrderBy(s => s.FirstName);
            Console.WriteLine("Students from group 2 ordered by first name:\n" + string.Join(", ", studentsFromGroupTwo) + "\n");

            // Task 10
            var studentsFromGroupTwo2 = list.SortByGroupAndFirstName(2);
            Console.WriteLine("Students from group 2 ordered by first name (task10):\n" + string.Join(", ", studentsFromGroupTwo2) + "\n");

            // Task 11
            Regex regEmail = new Regex("@abv\\.bg");
            var emailSorted = list.Where(s => regEmail.IsMatch(s.Email));
            Console.WriteLine("Sorted by email:\n" + string.Join(", ", emailSorted) + "\n");

            // Task 12 
            Regex regTel = new Regex("02/");
            var telSorted = list.Where(s => regTel.IsMatch(s.Tel));
            Console.WriteLine("Sorted by tel:\n" + string.Join(", ", telSorted) + "\n");

            // Task 13
            var excellentStudents = list.Where(s => s.Marks.Contains(6));

            var anonymousList = new
            {
                FullName = excellentStudents.Select(s => s.FirstName + " " + s.LastName),
                Marks = excellentStudents.Select(s => s.Marks)
            };

            Console.WriteLine("Students with at least one excellent mark:");
            Console.WriteLine(string.Join(", ", anonymousList.FullName) + "\n");

            // task 14
            var loosers = list.ExtractLoosers();
            Console.WriteLine("Students with exactly two bad(2) marks: ");
            Console.WriteLine(string.Join(", ", loosers) + "\n");

            // Task 15
            var classOf2006 = list.ExtractClassOf2006();
            Console.WriteLine("Class of 2006:");
            Console.WriteLine(string.Join(", ", classOf2006) + "\n");
        }
    }
}
