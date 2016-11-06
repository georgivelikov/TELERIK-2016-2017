namespace Company.DataGenerator
{
    using Company.Data;

    public class ProjectsDataGenerator : IDataGenerator
    {
        public void GenerateData(CompanyEntities data, IRandomGenerator random, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var project = new Project { Name = random.GetRandomString(random.GetRandomNumber(5, 50)) };
                data.Projects.Add(project);
            }
        }
    }
}
