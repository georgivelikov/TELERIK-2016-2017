using Company.DataGenerator;

namespace DataImport.Importers
{
    public class DepartmentImporter : Importer
    {
        public DepartmentImporter(CompanyDbEntities db)
            : base(db)
        {
        }

        public override void Import(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var department = this.GenerateDepartment();
                this.Database.Departments.Add(department);
            }

            this.Database.SaveChanges();
        }

        private Department GenerateDepartment()
        {
            var departmentNameLength = RandomGenerator.Instance.GetRandomNumber(10, 50);
            var departmentName = RandomGenerator.Instance.GetRandomString(departmentNameLength);

            return new Department() { Name = departmentName };
        }
    }
}
