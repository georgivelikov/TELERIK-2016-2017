using Bridge.Enums;

namespace Bridge.Models.Drinks
{
    public class Cola : Drink
    {
        public Cola(decimal basePrice, DrinkType drinkType)
            : base(basePrice, drinkType)
        {
        }

        public override decimal TotalPrice()
        {
            if (this.DrinkType == DrinkType.Small)
            {
                return this.BasePrice * 0.9m;
            }
            else if (this.DrinkType == DrinkType.Medium)
            {
                return this.BasePrice;
            }
            else 
            {
                return this.BasePrice * 1.2m;
            }
        }
    }
}
