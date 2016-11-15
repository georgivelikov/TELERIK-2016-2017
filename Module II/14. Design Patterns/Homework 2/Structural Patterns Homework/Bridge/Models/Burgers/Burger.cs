using Bridge.Contracts;
using Bridge.Enums;

namespace Bridge.Models.Burgers
{
    public abstract class Burger : IBurger
    {
        public Burger(decimal basePrice, BurgerType burgerType)
        {
            this.BasePrice = basePrice;
            this.BurgerType = burgerType;
        }

        public BurgerType BurgerType { get; set; }

        public decimal BasePrice { get; set; }

        public abstract decimal TotalPrice();
    }
}
