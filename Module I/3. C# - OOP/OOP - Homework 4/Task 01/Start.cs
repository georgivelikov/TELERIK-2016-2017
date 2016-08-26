namespace Task_01
{
    using System;
    using System.Collections.Generic;

    using Task_01.People;
    using Task_01.School_Objects;

    public class Start
    {
        public static void Main()
        {
            Student s1 = new Student("Georgi", 13);
            Student s2 = new Student("Pesho", 12);
            Student s3 = new Student("Maria", 15);
            Student s4 = new Student("Todor", 16, "Awesome!");

            Discipline d1 = new Discipline("History", 10, 10);
            Discipline d2 = new Discipline("Mathematics", 20, 14, "Hard!");
            Discipline d3 = new Discipline("Physics", 12, 12);
            Discipline d4 = new Discipline("Biology", 15, 5);

            Teacher t1 = new Teacher("Ivanov", new List<Discipline> { d1, d4 });
            Teacher t2 = new Teacher("Petrov", new List<Discipline> { d2, d3 });

            Class c1 = new Class("Class A");
            Class c2 = new Class("Class B");

            c1.AddStudent(s1);
            c1.AddStudent(s2);
            c1.AddTeacher(t1);

            c2.AddStudent(s3);
            c2.AddStudent(s4);
            c2.AddTeacher(t2);
            c2.AddTeacher(t1);

            School school = new School();
            school.AddClass(c1);
            school.AddClass(c2);

            foreach (var cl in school.Classes)
            {
                Console.WriteLine(cl);
            }
        }
    }
}
