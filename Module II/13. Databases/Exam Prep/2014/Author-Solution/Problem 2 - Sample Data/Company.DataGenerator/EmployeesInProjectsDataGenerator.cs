namespace Company.DataGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Company.Data;

    public class EmployeesInProjectsDataGenerator : IDataGenerator
    {
        public void GenerateData(CompanyEntities data, IRandomGenerator random, int count)
        {
            var employeeIds = data.Employees.Select(e => e.Id).ToList();
            var projectIds = data.Projects.Select(p => p.Id).ToList();

            foreach (var employeeId in employeeIds)
            {
                var employeeProjectsCount = random.GetRandomNumber((int)(count * 0.5), (int)(count * 1.5));
                var currentProjects = new HashSet<int>();

                while (currentProjects.Count < employeeProjectsCount)
                {
                    var randomProjectId = projectIds[random.GetRandomNumber(0, projectIds.Count - 1)];
                    currentProjects.Add(randomProjectId);
                }

                foreach (var projectId in currentProjects)
                {
                    var endDateTimeSpan = random.GetRandomNumber(-500, 1000);
                    var startDateTimeSpan = endDateTimeSpan + random.GetRandomNumber(1, 500);

                    data.EmployeesInProjects.Add(new EmployeesInProject
                                                     {
                                                         EmployeeId = employeeId,
                                                         ProjectId = projectId,
                                                         StartDate = DateTime.Now.AddDays(-startDateTimeSpan),
                                                         EndDate = DateTime.Now.AddDays(-endDateTimeSpan)
                                                     });
                }
            }
        }
    }
}