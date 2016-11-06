using System;
using System.Data.Entity;
using System.Linq;

using StudentSystem.Data;
using StudentSystem.Data.Migrations;
using StudentSystem.Models;

namespace StudentSystem.ConsoleClient
{
    public class StartUp
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemDbContext, Configuration>());

            var db = new StudentSystemDbContext();

            var student3 = db.Students.FirstOrDefault(s => s.Id == 3);
            var homework1 = db.Homeworks.FirstOrDefault(h => h.Id == 1);
            var course2 = db.Courses.FirstOrDefault(c => c.Id == 2);

            foreach (var st in db.Students)
            {
                Console.WriteLine(st.Name);
            }

            AddHomeworkToCourse(homework1, course2);
            AddStudentToCourse(student3, course2);
            AddHomeworkToStudent(homework1, student3);

            Console.WriteLine($"I am {student3.Name} and I study {course2.Name} and my homework is {homework1.Content} and its deadline is {homework1.TimeSent}");

            db.SaveChanges();

        }

        private static void AddStudentToCourse(Student student, Course course)
        {
            student.Courses.Add(course);
            course.Students.Add(student);
        }

        private static void AddHomeworkToCourse(Homework homework, Course course)
        {
            course.Homeworks.Add(homework);
        }

        private static void AddHomeworkToStudent(Homework homework, Student student)
        {
            student.Homeworks.Add(homework);
        }
    }
}
