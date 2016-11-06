using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_01
{
    using Task_01.Contracts;
    using Task_01.Models;
    using Task_01.Models.Vegetables;

    public class StartUp
    {
        public static void Main()
        {
            var carrotOne = new Carrot();
            var carrotTwo = new Carrot();
            var potatoOne = new Potato();
            var potatoTwo = new Potato();
            var potatoThree = new Potato();

            string mealName = "Vegetable soup with 2 carrots and 3 potatoes";

            List<IVegetable> ingredients = new List<IVegetable>
                                               {
                                                   carrotOne,
                                                   carrotTwo,
                                                   potatoOne,
                                                   potatoTwo,
                                                   potatoThree
                                               };

            var bowl = new Bowl();

            var chef = new Chef();

            var vegetableSoup = chef.CookMeal(bowl, ingredients, mealName);
            // Console.WriteLine(vegetableSoup.CaloriesReport());

            var mealsReport = chef.MealsReport();

            // Calories expected: 2 * 5 from carrots + 3 * 20 from potatoes = 70;
            Console.WriteLine(mealsReport);
        }
    }
}
