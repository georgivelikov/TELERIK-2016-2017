using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Category
{
    using Cosmetics.Common;
    using Cosmetics.Contracts;
    using Cosmetics.Products;

    public class Category : ICategory
    {
        private const int MinNameLen = 2;
        private const int MaxNameLen = 15;
        private string name;
        private ICollection<IProduct> productList;

        public Category(string name)
        {
            this.Name = name;
            this.productList = new List<IProduct>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Validator.CheckIfStringLengthIsValid(value, MaxNameLen, MinNameLen, string.Format(GlobalErrorMessages.InvalidStringLength, "Category name", MinNameLen, MaxNameLen));
                this.name = value;
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            Validator.CheckIfNull(cosmetics, string.Format(GlobalErrorMessages.ObjectCannotBeNull, "Product"));
            this.productList.Add(cosmetics);
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            var pr = this.productList.FirstOrDefault(p => p.Name == cosmetics.Name && p.Brand == cosmetics.Brand);
            Validator.CheckIfNull(pr, string.Format(GlobalErrorMessages.ProductDoesNotExist, cosmetics.Name, cosmetics.Brand));
            this.productList.Remove(pr);
        }

        public string Print()
        {
            StringBuilder sb = new StringBuilder();

            if (this.productList.Count != 1)
            {
                sb.AppendLine(
                    string.Format("{0} category - {1} products in total", this.Name, this.productList.ToList().Count));
            }
            else
            {
                sb.AppendLine(
                    string.Format("{0} category - {1} product in total", this.Name, this.productList.ToList().Count));
            }
            var sorted = this.productList.OrderBy(p => p.Brand).ThenByDescending(p => p.Price);
            foreach (var prod in sorted)
            {
                sb.AppendLine(prod.Print().Trim());
            }

            return sb.ToString().Trim();
        }
    }
}
