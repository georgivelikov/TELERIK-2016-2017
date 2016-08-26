namespace Task_01.People
{
    using System.Collections.Generic;
    using Task_01.School_Objects;

    public class Teacher : Person
    {
        private List<Discipline> disciplines;

        public Teacher(string name, string comment = null)
            : base(name, comment)
        {
            this.disciplines = new List<Discipline>();
        }

        public Teacher(string name, List<Discipline> disciplines, string comment = null)
            : base(name, comment)
        {
            this.disciplines = new List<Discipline>(disciplines);
        }

        public IEnumerable<Discipline> Disciplines
        {
            get
            {
                return this.disciplines;
            }
        }

        // With IEnumerable<> we encapsulate the list
        public void AddDiscipline(Discipline discipline)
        {
            // add some validation for the discipline if needed
            this.disciplines.Add(discipline);
        }

        public override string ToString()
        {
            return this.Name + ": " + string.Join(", ", this.Disciplines);
        }
    }
}
