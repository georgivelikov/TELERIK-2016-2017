using System;
using System.Collections.Generic;
using InheritanceAndPolymorphism.Courses;

namespace InheritanceAndPolymorphism
{
    class CoursesExamples
    {
        static void Main()
        {
            LocalCourse localCourse = new LocalCourse("Databases");
            Console.WriteLine(localCourse);

            localCourse.Lab = "Enterprise";
            Console.WriteLine(localCourse);

            List<string> studentsList = new List<string>() { "Peter", "Maria" };
            localCourse.AddStudent(studentsList[0]);
            localCourse.AddStudent(studentsList[1]);
            Console.WriteLine(localCourse);

            localCourse.TeacherName = "Svetlin Nakov";
            localCourse.AddStudent("Milena");
            localCourse.AddStudent("Todor");
            Console.WriteLine(localCourse);

            OffsiteCourse offsiteCourse = new OffsiteCourse(
                "PHP and WordPress Development",
                "Mario Peshev",
                new List<string>() { "Thomas", "Ani", "Steve" });
            Console.WriteLine(offsiteCourse);
        }
    }
}
