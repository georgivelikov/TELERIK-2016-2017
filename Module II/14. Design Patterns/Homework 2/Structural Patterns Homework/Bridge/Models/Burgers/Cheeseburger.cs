using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Models.Burgers
{
    using Bridge.Enums;

    public class Cheeseburger : Burger
    {
        public Cheeseburger(decimal basePrice, BurgerType burgerType)
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
                return this.BasePrice * 1.5m;
            }
        }
    }
}
