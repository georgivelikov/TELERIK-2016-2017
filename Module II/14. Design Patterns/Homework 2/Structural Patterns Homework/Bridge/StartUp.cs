using System;
using Bridge.Contracts;
using Bridge.Enums;
using Bridge.Models;
using Bridge.Models.Burgers;
using Bridge.Models.Drinks;

namespace Bridge
{
    public class StartUp
    {
        public static void Main()
        {
            IBurger cheeseBurger = new Cheeseburger(2.99m, BurgerType.Double);
            IDrink smallFanta = new Fanta(1m, DrinkType.Small);
            IMenu firstMenu = new Menu(cheeseBurger, smallFanta);
            Console.WriteLine(firstMenu);

            IBurger bigMac = new BigMac(5.19m, BurgerType.Normal);
            IDrink largeCola = new Cola(1m, DrinkType.Large);
            IMenu secondMenu = new Menu(bigMac, largeCola);
            Console.WriteLine(secondMenu);

            IBurger doubleBigMac = new BigMac(5.19m, BurgerType.Double);
            IDrink mediumCola = new Cola(1m, DrinkType.Medium);
            IMenu thirdMenu = new Menu(doubleBigMac, mediumCola);
            Console.WriteLine(thirdMenu);
        }
    }
}
