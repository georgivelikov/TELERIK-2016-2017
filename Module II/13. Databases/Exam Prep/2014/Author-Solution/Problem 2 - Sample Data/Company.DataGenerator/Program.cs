namespace Company.DataGenerator
{
    using System;
    using System.Collections.Generic;

    using Company.Data;

    public class Program
    {
        public static void Main()
        {
            var dataGeneratorExecutors = new List<DataGeneratorExecutor>
                                             {
                                                 new DataGeneratorExecutor(new DepartmentDataGenerator(), 100),
                                                 new DataGeneratorExecutor(new EmployeeDataGenerator(), 5000),
                                                 new DataGeneratorExecutor(new ProjectsDataGenerator(), 1000),
                                                 new DataGeneratorExecutor(new EmployeesInProjectsDataGenerator(), 10), // per employee
                                                 new DataGeneratorExecutor(new ReportsDataGenerator(), 50), // per employee
                                             };

            foreach (var dataGeneratorExecutor in dataGeneratorExecutors)
            {
                using (var data = new CompanyEntities())
                {
                    data.Configuration.AutoDetectChangesEnabled = false;
                    //// data.Configuration.ProxyCreationEnabled = false;

                    Console.WriteLine("Staring {0}...", dataGeneratorExecutor.DataGenerator.GetType().Name);
                    dataGeneratorExecutor.Execute(data, RandomGenerator.Instance);
                    Console.WriteLine("Saving {0}...", dataGeneratorExecutor.DataGenerator.GetType().Name);
                    data.SaveChanges();
                    Console.WriteLine("Finished {0}.", dataGeneratorExecutor.DataGenerator.GetType().Name);
                }
            }
        }
    }
}
