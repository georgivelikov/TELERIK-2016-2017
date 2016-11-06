using DataImport.Importers;

namespace DataImport
{
    public class Startup
    {
        public static void Main()
        {

            var db = new CompanyDbEntities();
            db.Configuration.AutoDetectChangesEnabled = false;
            db.Configuration.ValidateOnSaveEnabled = false;

            var departmentImporter = new DepartmentImporter(db);
            departmentImporter.Import(100);

            var employeeImporter = new EmployeeImporter(db);
            employeeImporter.Import(5000);
        }
    }
}
