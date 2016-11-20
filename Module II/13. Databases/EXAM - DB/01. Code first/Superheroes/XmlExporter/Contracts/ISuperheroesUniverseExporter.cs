namespace XmlExporter.Contracts
{
    public interface ISuperheroesUniverseExporter
    {
        string ExportAllSuperheroes();

        string ExportSupperheroesWithPower(string power);

        string ExportSuperheroDetails(object superheroId);

        string ExportFractions();

        string ExportFractionDetails(object fractionId);

        string ExportSuperheroesByCity(string cityName);
    }
}
