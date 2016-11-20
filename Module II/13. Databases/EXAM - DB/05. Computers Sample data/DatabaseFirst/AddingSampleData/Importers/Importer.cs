namespace AddingSampleData.Importers
{
    public abstract class Importer
    {
        private ComputersDbEntities db;

        public Importer(ComputersDbEntities db)
        {
            this.db = db;
        }

        protected ComputersDbEntities Database
        {
            get
            {
                return this.db;
            }
        }

        public abstract void Import(int count);
    }
}
