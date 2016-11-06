using Task_01.Contracts;

namespace Task_01.Models
{
    using System.Collections.Generic;
    using System.Text;

    public class Chef : IChef
    {
        private HashSet<IMeal> mealsCooked;

        public Chef()
        {
            this.mealsCooked = new HashSet<IMeal>();
        } 

        public IMeal CookMeal(IBowl bowl, ICollection<IVegetable> ingredients, string mealName)
        {
            foreach (var ingredient in ingredients)
            {
                this.Peel(ingredient);
                this.Cut(ingredient);
                bowl.AddIngredient(ingredient);
            }

            var meal = bowl.Boil(mealName);
            this.mealsCooked.Add(meal);
            return meal;
        }

        public string MealsReport()
        {
            StringBuilder strigBuilder = new StringBuilder();
            foreach (var meal in this.mealsCooked)
            {
                strigBuilder.AppendLine(meal.CaloriesReport());
            }

            return strigBuilder.ToString().Trim();
        }

        public void Peel(IVegetable vegetable)
        {
            vegetable.IsPeeled = true;
        }

        public void Cut(IVegetable vegetable)
        {
            vegetable.IsCut = true;
        }
    }
}
