using System.Collections.Generic;

namespace Task_01.Contracts
{
    public interface IChef
    {
        IMeal CookMeal(IBowl bowl, ICollection<IVegetable> ingredients, string mealName);

        string MealsReport();
    }
}
