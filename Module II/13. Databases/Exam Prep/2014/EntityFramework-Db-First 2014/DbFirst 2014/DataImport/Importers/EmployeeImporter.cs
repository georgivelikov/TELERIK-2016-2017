using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Company.DataGenerator;

namespace DataImport.Importers
{
    public class EmployeeImporter : Importer
    {
        public EmployeeImporter(CompanyDbEntities db)
            : base(db)
        {
        }

        public override void Import(int count)
        {
            var noManagerCount = (int)(count * 0.05);
            var departmentIds = this.Database.Departments.Select(d => d.Id).ToList();
            var employeeCount = 0;

            for (int i = 0; i < noManagerCount; i++)
            {
                var departmentId = departmentIds[RandomGenerator.Instance.GetRandomNumber(0, departmentIds.Count - 1)];
                var managerId = 0;

                var employee = this.GenerateEmployee(departmentId, managerId);
                this.Database.Employees.Add(employee);

                employeeCount++;

                if (employeeCount % 100 == 0)
                {
                    Console.WriteLine(employeeCount);
                }
            }

            this.Database.SaveChanges();

            for (int i = 0; i < count - noManagerCount; i++)
            {
                var startingId = this.Database.Employees.First().Id;
                var departmentId = departmentIds[RandomGenerator.Instance.GetRandomNumber(0, departmentIds.Count - 1)];
                var managerId = RandomGenerator.Instance.GetRandomNumber(startingId, startingId + employeeCount);

                var employee = this.GenerateEmployee(departmentId, managerId);

                this.Database.Employees.Add(employee);

                employeeCount++;
                
                if (employeeCount % 100 == 0)
                {
                    Console.WriteLine(employeeCount);
                }
            }

            this.Database.SaveChanges();
        }

        private Employee GenerateEmployee(int departmentId, int managerId)
        {
            var employee = new Employee
            {
                FirstName = RandomGenerator.Instance.GetRandomString(RandomGenerator.Instance.GetRandomNumber(5, 20)),
                LastName = RandomGenerator.Instance.GetRandomString(RandomGenerator.Instance.GetRandomNumber(5, 20)),
                YearSalary = RandomGenerator.Instance.GetRandomNumber(50000, 200000),
                DepartmentId = departmentId
            };

            if (managerId != 0)
            {
                employee.ManagerId = managerId;
            }

            return employee;
        }
    }
}
