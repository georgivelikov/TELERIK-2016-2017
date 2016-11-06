using System.Data.Entity;

using StudentSystem.Models;

namespace StudentSystem.Data
{
    public class StudentSystemDbContext : DbContext
    {
        public StudentSystemDbContext() 
            :base("StudentSystemDb")
        {
            
        }
        public virtual IDbSet<Student> Students { get; set; }

        public virtual IDbSet<Homework> Homeworks { get; set; }

        public virtual IDbSet<Course> Courses { get; set; }
    }
}
