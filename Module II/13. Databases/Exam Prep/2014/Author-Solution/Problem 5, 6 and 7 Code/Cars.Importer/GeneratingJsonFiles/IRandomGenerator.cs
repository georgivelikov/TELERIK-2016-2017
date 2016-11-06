namespace Cars.Importer.GeneratingJsonFiles
{
    using System.Collections.Generic;

    public interface IRandomGenerator
    {
        int GetRandomNumber(int min, int max);

        string GetRandomString(int length);

        IEnumerable<string> GetRandomStrings(int count, int length);

        T GetRandomElement<T>(IList<T> collection);
    }
}
