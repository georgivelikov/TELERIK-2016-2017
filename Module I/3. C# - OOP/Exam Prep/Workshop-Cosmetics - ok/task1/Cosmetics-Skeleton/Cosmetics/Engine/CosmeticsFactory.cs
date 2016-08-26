namespace Cosmetics.Engine
{
    using System.Collections.Generic;

    using Cosmetics.Common;
    using Cosmetics.Contracts;
    using Cosmetics.Products;
    using Cart;

    using Cosmetics.Category;

    public class CosmeticsFactory : ICosmeticsFactory
    {
        public ICategory CreateCategory(string name)
        {
            var cat = new Category(name);
            return cat;
        }

        public Shampoo CreateShampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
        {
            var shampoo = new Shampoo(name, brand, price, gender, usage, milliliters);
            return shampoo;
        }

        public IToothpaste CreateToothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients)
        {
            var toothpaste = new Toothpaste(name, brand, price, gender);
            foreach (var ing in ingredients)
            {
                toothpaste.AddIngredient(ing);
            }

            return toothpaste;
        }

        public ShoppingCart ShoppingCart()
        {
            var shoppingCart = new ShoppingCart();
            return shoppingCart;
        }
    }
}
