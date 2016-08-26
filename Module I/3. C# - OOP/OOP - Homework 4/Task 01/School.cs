namespace Task_01
{
    using System.Collections.Generic;

    using Task_01.School_Objects;

    public class School
    {
        private List<Class> classes;

        public School()
        {
            this.classes = new List<Class>();
        }

        public IEnumerable<Class> Classes
        {
            get
            {
                return this.classes;
            }
        }

        public void AddClass(Class c)
        {
            this.classes.Add(c);
        }
    }
}
