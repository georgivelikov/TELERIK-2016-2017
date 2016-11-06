namespace Company.DataGenerator
{
    using System.Collections.Generic;

    using Company.Data;

    public class DepartmentDataGenerator : IDataGenerator
    {
        public void GenerateData(CompanyEntities data, IRandomGenerator random, int count)
        {
            var uniqueNames = new HashSet<string>();

            while (uniqueNames.Count < count)
            {
                uniqueNames.Add(random.GetRandomString(random.GetRandomNumber(10, 50)));
            }

            foreach (var uniqueName in uniqueNames)
            {
                var department = new Department { Name = uniqueName };
                data.Departments.Add(department);
            }
        }
    }
}
