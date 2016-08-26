namespace Cosmetics.Cart
{
    using System.Collections.Generic;

    using Cosmetics.Contracts;

    public class ShoppingCart
    {
        private ICollection<IProduct> productList;

        public ShoppingCart()
        {
            this.productList = new List<IProduct>();
        }

        public ICollection<IProduct> ProductList
        {
            get { return this.productList; }
            private set { this.productList = value; }
        }

        public void AddProduct(IProduct product)
        {
            this.productList.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            this.productList.Remove(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            return this.productList.Contains(product);
        }

        public decimal TotalPrice()
        {
            decimal result = 0;
            foreach (var prod in this.productList)
            {
                result += prod.Price;
            }

            return result;
        }
    }
}
