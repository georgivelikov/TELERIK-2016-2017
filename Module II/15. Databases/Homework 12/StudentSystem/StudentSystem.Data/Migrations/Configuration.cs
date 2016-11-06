using System;
using System.Data.Entity.Migrations;

using StudentSystem.Models;

namespace StudentSystem.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.ContextKey = "StudentSystem.Data.StudentSystemDbContext";
        }

        protected override void Seed(StudentSystemDbContext context)
        {
            this.SeedStudents(context);
            this.SeedCourses(context);
            this.SeedHomeworks(context);
        }

        private void SeedStudents(StudentSystemDbContext context)
        {
            context.Students.AddOrUpdate(s => s.Name,
                new Student
                {
                    Name = "Georgi Petkanov",
                    StudentNumber = 123456
                },
                new Student()
                {
                    Name = "Ivan Petrov",
                    StudentNumber = 111111
                },
                new Student()
                {
                    Name = "Maria Petkova",
                    StudentNumber = 234156
                }
            );
        }

        private void SeedCourses(StudentSystemDbContext context)
        {
            context.Courses.AddOrUpdate(c => c.Name,
                new Course()
                {
                    Name = "Biology",
                    Description = "Stupid Course"
                },
                new Course()
                {
                    Name = "Databases",
                    Description = "Easy, actually"
                }
            );
        }

        private void SeedHomeworks(StudentSystemDbContext context)
        {
            context.Homeworks.AddOrUpdate(h => h.Content,
                new Homework()
                {
                    Content = "Easy Homework",
                    TimeSent = new DateTime(2016, 12, 12),
                    CourseId = 1
                },
                new Homework()
                {
                    Content = "Medium Homework",
                    TimeSent = new DateTime(2016, 10, 12),
                    CourseId = 1
                },
                new Homework()
                {
                    Content = "Hard Homework",
                    TimeSent = new DateTime(2016, 11, 11),
                    CourseId = 2
                }
            );
        }


    }
}
