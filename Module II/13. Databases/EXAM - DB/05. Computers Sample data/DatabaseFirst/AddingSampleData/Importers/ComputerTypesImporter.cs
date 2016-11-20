namespace AddingSampleData.Importers
{
    public class ComputerTypesImporter : Importer
    {
        public ComputerTypesImporter(ComputersDbEntities db)
            : base(db)
        {
        }

        public override void Import(int count)
        {
            var computerType1 = new ComputerType() { Type = "Notebook" };
            var computerType2 = new ComputerType() { Type = "Desktop" };
            var computerType3 = new ComputerType() { Type = "Ultrabook" };

            this.Database.ComputerTypes.Add(computerType1);
            this.Database.ComputerTypes.Add(computerType2);
            this.Database.ComputerTypes.Add(computerType3);

            this.Database.SaveChanges();
        }
    }
}
