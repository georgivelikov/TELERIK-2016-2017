namespace Task_01.Contracts
{
    public interface IBowl
    {
        void AddIngredient(IVegetable vegetable);

        IMeal Boil(string mealName);
    }
}
