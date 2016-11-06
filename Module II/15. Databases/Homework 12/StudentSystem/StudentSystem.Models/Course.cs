using System.Collections.Generic;

namespace StudentSystem.Models
{
    public class Course
    {
        private ICollection<Homework> homeworks;

        private ICollection<Student> students;
         
        public Course()
        {
            this.homeworks = new HashSet<Homework>();
            this.students = new HashSet<Student>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Homework> Homeworks
        {
            get
            {
                return this.homeworks;
            }

            set
            {
                this.homeworks = value;
            }
        }

        public virtual ICollection<Student> Students {
            get
            {
                return this.students;
            }

            set
            {
                this.students = value;
            }
        }
    }
}
