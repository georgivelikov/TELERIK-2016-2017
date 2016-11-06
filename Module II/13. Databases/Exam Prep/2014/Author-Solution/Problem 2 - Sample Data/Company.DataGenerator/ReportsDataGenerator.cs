namespace Company.DataGenerator
{
    using System;
    using System.Linq;

    using Company.Data;

    public class ReportsDataGenerator : IDataGenerator
    {
        public void GenerateData(CompanyEntities data, IRandomGenerator random, int count)
        {
            var employeeIds = data.Employees.Select(e => e.Id).ToList();

            foreach (var employeeId in employeeIds)
            {
                var reportsCount = random.GetRandomNumber((int)(0.5 * count), (int)(1.5 * count));

                for (int i = 0; i < reportsCount; i++)
                {
                    var timeSpanForReport = random.GetRandomNumber(0, 60 * 60 * 24 * 1000);

                    var report = new Report
                                     {
                                         EmployeeId = employeeId,
                                         Time = DateTime.Now.AddSeconds(-timeSpanForReport)
                                     };

                    data.Reports.Add(report);
                }
            }
        }
    }
}