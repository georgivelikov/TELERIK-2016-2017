namespace Tasks09___15
{
    using System.Collections.Generic;
    using System.Linq;

    public static class Extensions
    {
        public static IEnumerable<Student> SortByGroupAndFirstName(this List<Student> list, int groupNumber)
        {
            var results = new List<Student>();
            foreach (var student in list)
            {
                if (student.GroupNumber == groupNumber)
                {
                    results.Add(student);
                }
            }

            var sorted = results.OrderBy(s => s.FirstName);

            return sorted;
        }

        public static IEnumerable<Student> ExtractLoosers(this List<Student> list)
        {
            var results = new List<Student>();
            foreach (var student in list)
            {
                int counter = 0;
                for (int i = 0; i < student.Marks.Count; i++)
                {
                    if (student.Marks[i] == 2)
                    {
                        counter++;
                    }
                }

                if (counter == 2)
                {
                    results.Add(student);
                }
            }

            return results;
        }

        public static IEnumerable<Student> ExtractClassOf2006(this List<Student> list)
        {
            var results = new List<Student>();
            foreach (var student in list)
            {
                string number = student.FN.ToString();

                if (number[number.Length - 1] == '6' && number[number.Length - 2] == '0')
                {
                    results.Add(student);
                }
            }

            return results;
        }
    }
}
