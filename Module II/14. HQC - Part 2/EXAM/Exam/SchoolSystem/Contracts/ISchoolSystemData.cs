using SchoolSystem.Models;

namespace SchoolSystem.Contracts
{
    public interface ISchoolSystemData
    {
        void AddTeacher(Teacher teacher);

        void AddStudent(Student student);

        void RemoveTeacher(int id);

        void RemoveStudent(int id);

        Teacher GetTeacher(int id);

        Student GetStudent(int id);

        int LastStudentId();

        int LastTeacherId();

        int TeachersCount();

        int StudentsCount();
    }
}
