using Bridge.Contracts;

namespace Bridge.Models
{    public class Menu : IMenu
    {
        public Menu(IBurger burger, IDrink drink)
        {
            this.Burger = burger;
            this.Drink = drink;
        }

        public IBurger Burger { get; set; }

        public IDrink Drink { get; set; }

        public decimal TotalPrice()
        {
            return this.Burger.TotalPrice() + this.Drink.TotalPrice();
        }

        public override string ToString()
        {
            return $"{this.Burger.BurgerType} {this.Burger.GetType().Name} with {this.Drink.DrinkType} {this.Drink.GetType().Name}\nTotal Price: {this.TotalPrice():F2}";
        }
    }
}
