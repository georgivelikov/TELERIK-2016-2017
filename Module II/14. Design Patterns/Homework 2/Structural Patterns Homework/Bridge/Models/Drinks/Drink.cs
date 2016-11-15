using Bridge.Contracts;
using Bridge.Enums;

namespace Bridge.Models.Drinks
{
    public abstract class Drink : IDrink
    {
        public Drink(decimal basePrice, DrinkType drinkType)
        {
            this.BasePrice = basePrice;
            this.DrinkType = drinkType;
        }

        public decimal BasePrice { get; set; }

        public DrinkType DrinkType { get; set; }

        public abstract decimal TotalPrice();
    }
}
