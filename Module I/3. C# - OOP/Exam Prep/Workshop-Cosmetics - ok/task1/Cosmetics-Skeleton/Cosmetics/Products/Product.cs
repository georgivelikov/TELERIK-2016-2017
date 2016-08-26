namespace Cosmetics.Products
{
    using System;
    using System.Text;

    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public abstract class Product : IProduct
    {
        private const int MinLenOfName = 3;
        private const int MaxLenOfName = 10;
        private const int MinLenOfBrand = 2;
        private const int MaxLenOfBrand = 10;

        private string name;
        private string brand;
        private decimal price;
        private GenderType gender;

        public Product(string name, string brand, decimal price, GenderType genger)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = genger;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Validator.CheckIfStringLengthIsValid(value, MaxLenOfName, MinLenOfName, string.Format(GlobalErrorMessages.InvalidStringLength, "Product name", MinLenOfName, MaxLenOfName));
                this.name = value;
            }
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }

            set
            {
                Validator.CheckIfStringLengthIsValid(value, MaxLenOfBrand, MinLenOfBrand, string.Format(GlobalErrorMessages.InvalidStringLength, "Product brand", MinLenOfBrand, MaxLenOfBrand));
                this.brand = value;
            }
        }

        public virtual decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                this.price = value;
            }
        }

        public GenderType Gender
        {
            get
            {
                return this.gender;
            }

            set
            {
                this.gender = value;
            }
        }

        public virtual string Print()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("- {0} - {1}:", this.Brand, this.Name));
            sb.AppendLine(string.Format(" * Price: ${0}", this.Price));
            sb.AppendLine(string.Format(" * For gender: {0}", this.Gender));

            return sb.ToString().Trim();

        }
    }
}
