using System.Collections.Generic;

using SchoolSystem.Framework.Common;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Contracts;

namespace SchoolSystem.Framework.Core.Providers
{
    public class SchoolSystemData : ISchoolSystemData
    {
        private IDictionary<int, ITeacher> teachers;
        private IDictionary<int, IStudent> students;

        private int currentStudentId;

        private int currentTeacherId;

        public SchoolSystemData()
        {
            this.teachers = new Dictionary<int, ITeacher>();
            this.students = new Dictionary<int, IStudent>();
        }

        public void AddTeacher(ITeacher teacher)
        {
            this.currentTeacherId = IdCounter.Instance.GetTeacherId();
            this.teachers.Add(this.currentTeacherId, teacher);
        }

        public void AddStudent(IStudent student)
        {
            this.currentStudentId = IdCounter.Instance.GetStudentId();
            this.students.Add(this.currentStudentId, student);
        }

        public void RemoveTeacher(int id)
        {
            this.teachers.Remove(id);
        }

        public void RemoveStudent(int id)
        {
            this.students.Remove(id);
        }

        public ITeacher GetTeacher(int id)
        {
            return this.teachers[id];
        }

        public IStudent GetStudent(int id)
        {
            return this.students[id];
        }

        public int LastStudentId()
        {
            return this.currentStudentId;
        }

        public int LastTeacherId()
        {
            return this.currentTeacherId;
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
