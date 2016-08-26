namespace Cosmetics.Products
{
    using System.Collections.Generic;
    using System.Text;

    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public class Toothpaste : Product, IToothpaste
    {
        private const int MinIngLen = 4;
        private const int MaxIngLen = 12;

        private List<string> ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType genger)
            : base(name, brand, price, genger)
        {
            this.ingredients = new List<string>();
        }

        public IEnumerable<string> ListOfIngredientds
        {
            get
            {
                return this.ingredients;
            }
        }

        public string Ingredients
        {
            get
            {
                return string.Join(", ", this.ingredients);
            }
        }

        public void AddIngredient(string ingredientName)
        {
            Validator.CheckIfStringLengthIsValid(ingredientName, MaxIngLen, MinIngLen, string.Format(GlobalErrorMessages.InvalidStringLength, "Each ingredient", MinIngLen, MaxIngLen));
            this.ingredients.Add(ingredientName);
        }

        public override string Print()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.Print());
            sb.AppendLine(string.Format(" * Ingredients: {0}", this.Ingredients));

            return sb.ToString().Trim();
        }
    }
}
