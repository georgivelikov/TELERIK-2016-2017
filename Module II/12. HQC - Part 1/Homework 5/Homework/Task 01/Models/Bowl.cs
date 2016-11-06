using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_01.Contracts;

namespace Task_01.Models
{
    
    public class Bowl : IBowl
    {
        private HashSet<IVegetable> ingredients;
         
        public Bowl()
        {
            this.ingredients = new HashSet<IVegetable>();
        }

        public void AddIngredient(IVegetable vegetable)
        {
            if (!vegetable.IsPeeled)
            {
                throw new InvalidOperationException("Ingredient is not peeled!");
            }

            if (!vegetable.IsCut)
            {
                throw new InvalidOperationException("Ingredient is not cut!");
            }

            this.ingredients.Add(vegetable);
        }

        public IMeal Boil(string mealName)
        {
            var mealCalories = this.CalculateCaloriesInBowl();

            return new Soup(mealCalories, mealName);
        }

        private double CalculateCaloriesInBowl()
        {
            double sumOfCalories = 0;

            foreach (var vegetable in this.ingredients)
            {
                sumOfCalories += vegetable.Calories;
            }

            return sumOfCalories;
        }
    }
}
