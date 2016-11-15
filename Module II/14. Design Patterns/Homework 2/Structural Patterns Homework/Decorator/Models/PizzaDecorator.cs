using Decorator.Contracts;

namespace Decorator.Models
{
    using System.Collections.Generic;

    public class PizzaDecorator : Pizza
    {
        private IPizza pizza;

        public PizzaDecorator(IPizza pizza, string ingredient)
        {
            this.pizza = pizza;
            this.pizza.Ingredients.Add(ingredient);
        }

        public override ICollection<string> Ingredients
        {
            get
            {
                return this.pizza.Ingredients;
            }
        }

        public override void Display()
        {
            this.pizza.Display();
        }
    }
}
