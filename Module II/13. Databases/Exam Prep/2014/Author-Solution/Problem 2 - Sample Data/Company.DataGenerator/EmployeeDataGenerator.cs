namespace Company.DataGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Company.Data;

    public class EmployeeDataGenerator : IDataGenerator
    {
        public void GenerateData(CompanyEntities data, IRandomGenerator random, int count)
        {
            var allAddedEmployees = new List<Employee>();
            var departmentIds = data.Departments.Select(d => d.Id).ToList();

            for (int i = 0; i < count; i++)
            {
                var employee = new Employee
                                   {
                                       FirstName = random.GetRandomString(random.GetRandomNumber(5, 20)),
                                       LastName = random.GetRandomString(random.GetRandomNumber(5, 20)),
                                       Salary = random.GetRandomNumber(50000, 200000),
                                       DepartmentId =
                                           departmentIds[random.GetRandomNumber(0, departmentIds.Count - 1)]
                                   };

                if (allAddedEmployees.Count > 0 && random.GetRandomNumber(1, 100) <= 95)
                {
                    employee.Employee1 = allAddedEmployees[random.GetRandomNumber(0, allAddedEmployees.Count - 1)];
                }

                allAddedEmployees.Add(employee);
            }

            data.Employees.AddRange(allAddedEmployees);
        }
    }
}
