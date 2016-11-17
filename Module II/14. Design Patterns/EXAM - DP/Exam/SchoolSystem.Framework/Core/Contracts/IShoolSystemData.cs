using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Contracts;

namespace SchoolSystem.Framework.Core.Contracts
{
    public interface ISchoolSystemData
    {
        void AddTeacher(ITeacher teacher);

        void AddStudent(IStudent student);

        void RemoveTeacher(int id);

        void RemoveStudent(int id);

        ITeacher GetTeacher(int id);

        IStudent GetStudent(int id);

        int LastStudentId();

        int LastTeacherId();

        int TeachersCount();

        int StudentsCount();
    }
}
