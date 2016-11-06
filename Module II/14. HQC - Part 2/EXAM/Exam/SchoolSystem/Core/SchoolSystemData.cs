using System.Collections.Generic;
using SchoolSystem.Contracts;
using SchoolSystem.Models;

namespace SchoolSystem.Core
{
    public class SchoolSystemData : ISchoolSystemData
    {
        private IDictionary<int, Teacher> teachers;
        private IDictionary<int, Student> students;

        private int teachersIdCounter = 0;
        private int studentsIdCounter = 0;

        public SchoolSystemData()
        {
            this.teachers = new Dictionary<int, Teacher>();
            this.students = new Dictionary<int, Student>();
        }

        public void AddTeacher(Teacher teacher)
        {
            this.teachers.Add(this.teachersIdCounter, teacher);
            this.teachersIdCounter++;
        }

        public void AddStudent(Student student)
        {
            this.students.Add(this.studentsIdCounter, student);
            this.studentsIdCounter++;
        }

        public void RemoveTeacher(int id)
        {
            this.teachers.Remove(id);
        }

        public void RemoveStudent(int id)
        {
            this.students.Remove(id);
        }

        public Teacher GetTeacher(int id)
        {
            return this.teachers[id];
        }

        public Student GetStudent(int id)
        {
            return this.students[id];
        }

        public int LastStudentId()
        {
            return this.studentsIdCounter - 1;
        }

        public int LastTeacherId()
        {
            return this.teachersIdCounter - 1;
        }

        public int TeachersCount()
        {
            return this.teachers.Count;
        }

        public int StudentsCount()
        {
            return this.students.Count;
        }
    }
}
