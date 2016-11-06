namespace Task_01.Contracts
{
    public interface IMeal
    {
        string Name { get; }

        double Calories { get; }

        string CaloriesReport();
    }
}
