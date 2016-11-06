namespace Company.DataGenerator
{
    using Company.Data;

    public interface IDataGenerator
    {
        void GenerateData(CompanyEntities data, IRandomGenerator random, int count);
    }
}
