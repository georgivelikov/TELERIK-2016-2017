namespace Task_01.Contracts
{
    public interface IVegetable
    {
        double Calories { get; }

        bool IsPeeled { get; set; }

        bool IsCut { get; set; }
    }
}
