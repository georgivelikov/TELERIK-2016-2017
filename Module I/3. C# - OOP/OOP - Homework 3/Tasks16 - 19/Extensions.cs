namespace Tasks16___19
{

    using System.Collections.Generic;

    public static class Extensions
    {
        public static Dictionary<string, List<Student>> GroupByGroupName(this List<Student> list)
        {
            var results = new Dictionary<string, List<Student>>();
            foreach (var student in list)
            {
                if (!results.ContainsKey(student.Group.DepartmentName))
                {
                    results.Add(student.Group.DepartmentName, new List<Student>());
                }

                results[student.Group.DepartmentName].Add(student);
            }

            return results;
        }

    }
}
