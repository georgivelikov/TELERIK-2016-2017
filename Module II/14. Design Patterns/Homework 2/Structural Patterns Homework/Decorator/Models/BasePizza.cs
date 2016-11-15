using System;

namespace Decorator.Models
{
    public sealed class BasePizza : Pizza
    {
        public BasePizza() 
        {
            this.Ingredients.Add("mozarella");
            this.Ingredients.Add("tomatoes");
        }

        public override void Display()
        {
            Console.WriteLine("I am pizza with " + string.Join(", ", this.Ingredients));
        }
    }
}
