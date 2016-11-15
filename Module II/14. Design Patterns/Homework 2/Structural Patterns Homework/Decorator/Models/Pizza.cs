using System;
using System.Collections.Generic;
using Decorator.Contracts;

namespace Decorator.Models
{
    public abstract class Pizza : IPizza
    {
        private ICollection<string> ingredients;

        public Pizza()
        {
            this.ingredients = new List<string>();
        }

        public virtual ICollection<string> Ingredients
        {
            get
            {
                return this.ingredients;
            }
        }

        public abstract void Display();

    }
}
