namespace Cars.Importer.GeneratingJsonFiles
{
    public interface IJsonFilesGenerator
    {
        void Generate(int filesCount, IRandomGenerator random);
    }
}
