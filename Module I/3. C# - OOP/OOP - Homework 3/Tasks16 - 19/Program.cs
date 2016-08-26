namespace Tasks16___19
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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
                new Group(2, "History"));
            Student s2 = new Student(
                "Georgi",
                "Georgiev",
                132205,
                "042/323211",
                "georgi@gmail.com",
                new List<int>() { 2, 6, 4, 5, 6 },
                new Group(3, "Mathematics"));
            Student s3 = new Student(
                "Maria",
                "Todorova",
                113206,
                "052/123245",
                "maria@abv.bg",
                new List<int>() { 2, 3, 4, 3, 5 },
                new Group(2, "History"));
            Student s4 = new Student(
                "Petya",
                "Petrova",
                412203,
                "02/123451",
                "petya@gmail.com",
                new List<int>() { 2, 3, 4, 6, 6 },
                new Group(1, "Physics"));
            Student s5 = new Student(
                "Staman",
                "Gospodinov",
                612206,
                "02/123451",
                "stamba@gmail.com",
                new List<int>() { 6, 5, 4, 6, 6 },
                new Group(4, "Biology"));
            Student s6 = new Student(
                "Pencho",
                "Dimitrov",
                612205,
                "022/923451",
                "bomba@gmail.com",
                new List<int>() { 2, 2, 3, 5, 3 },
                new Group(4, "Biology"));
            Student s7 = new Student(
                "Slavcho",
                "Toshev",
                612206,
                "022/923451",
                "sexy@abv.bg",
                new List<int>() { 4, 5, 4, 5, 5 },
                new Group(3, "Mathematics"));
            Student s8 = new Student(
                "Antonia",
                "Petrova",
                512204,
                "032/923111",
                "antonia@gmail.com",
                new List<int>() { 4, 3, 6, 5, 6 },
                new Group(1, "Physics"));

            List<Student> list = new List<Student>() { s1, s2, s3, s4, s5, s6, s7, s8 };

            // Task 16
            Console.WriteLine("Students in Mathematics group:");
            var mathStudents = list.Where(s => s.Group.DepartmentName == "Mathematics");
            Console.WriteLine(string.Join(", ", mathStudents) + "\n");

            // Task 17
            var stringList = new List<string>() { "lo", "longest", "longer", "long" };
            var str = stringList.OrderByDescending(s => s.Length).FirstOrDefault();
            Console.WriteLine("Longest string: " + str + "\n");

            // Task 18
            var studentGroups = list.GroupBy(s => s.Group.GroupNumber);
            int grNumber = 1;
            foreach (var group in studentGroups)
            {
                Console.WriteLine("Group number {0}:", grNumber);
                Console.WriteLine(string.Join(", ", group));
                grNumber++;
            }

            Console.WriteLine();

            // Task 19
            var groupByDepartmentName = list.GroupByGroupName();
            foreach (var group in groupByDepartmentName)
            {
                Console.WriteLine(group.Key  + ":");
                Console.WriteLine(string.Join(", ", group.Value));
            }
        }
    }
}
