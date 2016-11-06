namespace Company.DataGenerator
{
    using Company.Data;

    public class DataGeneratorExecutor
    {
        private readonly IDataGenerator dataGenerator;

        private readonly int entriesCount;

        public DataGeneratorExecutor(IDataGenerator dataGenerator, int entriesCount)
        {
            this.dataGenerator = dataGenerator;
            this.entriesCount = entriesCount;
        }

        public int EntriesCount
        {
            get
            {
                return this.entriesCount;
            }
        }

        public IDataGenerator DataGenerator
        {
            get
            {
                return this.dataGenerator;
            }
        }

        public void Execute(CompanyEntities data, IRandomGenerator randomGenerator)
        {
            this.DataGenerator.GenerateData(data, randomGenerator, this.EntriesCount);
        }
    }
}
