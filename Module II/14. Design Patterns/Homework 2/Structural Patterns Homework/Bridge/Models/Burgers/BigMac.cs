using Bridge.Enums;

namespace Bridge.Models.Burgers
{
    public class BigMac : Burger
    {
        public BigMac(decimal basePrice, BurgerType burgerType)
            : base(basePrice, burgerType)
        {
        }

        public override decimal TotalPrice()
        {
            if (this.BurgerType == BurgerType.Normal)
            {
                return this.BasePrice;
            }
            else
            {
                return this.BasePrice * 1.7m;
            }
        }
    }
}
