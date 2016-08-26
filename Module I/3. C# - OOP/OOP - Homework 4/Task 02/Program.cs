namespace Task_02
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<Student> studentsList = new List<Student>
                                             {
                                                 new Student("Asen", "Asenov", 12),
                                                 new Student("Petar", "Ivanov", 2),
                                                 new Student("Angel", "Petrov", 4),
                                                 new Student("Petar", "Gospodinov", 12),
                                                 new Student("Maria", "Ivanova", 6),
                                                 new Student("Milen", "Dimitrov", 6),
                                                 new Student("Veselka", "Georgieva", 2),
                                                 new Student("Stoqnka", "Petkova", 3),
                                                 new Student("Ignat", "Kolev", 9),
                                                 new Student("Stefan", "Stefanov", 5),
                                             };
            List<Worker> workersList = new List<Worker>
                                           {
                                               new Worker("Georgi", "Markov", 400m, 8),
                                               new Worker("Veselin", "Marinov", 200m, 5),
                                               new Worker("Preslava", "Pavlova", 300m, 8),
                                               new Worker("Filip", "Naidenov", 300m, 8),
                                               new Worker("Stoyan", "Nedyalkov", 500m, 6),
                                               new Worker("Milen", "Velchev", 1400m, 12),
                                               new Worker("Dimitar", "Jeliazkov", 4000m, 16),
                                               new Worker("Georgi", "Kostadinov", 250m, 8),
                                               new Worker("Asen", "Blatechki", 500m, 10),
                                               new Worker("Dimitar", "Nikolov", 300m, 5),
                                           };

            var sortedStudents = studentsList.OrderBy(s => s.Grade);
            Console.WriteLine("Students:");
            Console.WriteLine(string.Join("\n", sortedStudents));
            Console.WriteLine(new string('-', 30));

            var sortedWorkers = workersList.OrderByDescending(w => w.MoneyPerHour());
            Console.WriteLine("Workers:");
            Console.WriteLine(string.Join("\n", sortedWorkers));
            Console.WriteLine(new string('-', 30));

            List<Human> list = new List<Human>();
            list.AddRange(studentsList);
            list.AddRange(workersList);

            var sortedList = list.OrderBy(h => h.FirstName).ThenBy(h => h.LastName);
            Console.WriteLine("All sorted alphabetically:");
            Console.WriteLine(string.Join("\n", sortedList));
        }
    }
}
