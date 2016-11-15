using Decorator.Models;

namespace Decorator
{
    public class StartUp
    {
        public static void Main()
        {
            var basePizza = new BasePizza();
            basePizza.Display();

            var basePizzaWithHam = new PizzaDecorator(basePizza, "ham");
            basePizzaWithHam.Display();
            
            var basePizzaWithHamAndMushrooms = new PizzaDecorator(basePizzaWithHam, "mushrooms");
            basePizzaWithHamAndMushrooms.Display();
        }
    }
}
