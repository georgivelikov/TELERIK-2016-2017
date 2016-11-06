namespace DataImport.Importers
{
    public abstract class Importer : IImporter
    {
        private CompanyDbEntities db;

        public Importer(CompanyDbEntities db)
        {
            this.db = db;
        }

        protected CompanyDbEntities Database
        {
            get
            {
                return this.db;
            }
        }

        public abstract void Import(int count);
    }
}
