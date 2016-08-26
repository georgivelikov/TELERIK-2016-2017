namespace FurnitureManufacturer.Models
{
    using System;

    using FurnitureManufacturer.Interfaces;

    public abstract class Furniture : IFurniture
    {
        private readonly string model;
        private readonly MaterialType material;
        private decimal price;
        private decimal height;

        protected Furniture(string model, MaterialType material, decimal price, decimal height)
        {
            this.ValidateModelName(model);
            this.ValidateMaterialType(material);

            this.model = model;
            this.material = material; // TO DO
            this.Price = price;
            this.Height = height;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
        }

        public string Material
        {
            get
            {
                return this.material.ToString();
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price cannot be less or equal to $0.00.");
                }

                this.price = value;
            }
        }

        public decimal Height
        {
            get
            {
                return this.height;
            }

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be less or equal to 0.00 m.");
                }

                this.height = value;
            }
        }

        public override string ToString()
        {
            string result = string.Format(
                "Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4:0.00}",
                this.GetType().Name,
                this.Model,
                this.Material,
                this.Price,
                this.Height);

            return result;
        }

        private void ValidateModelName(string modelName)
        {
            if (modelName.Length < 3 || string.IsNullOrWhiteSpace(modelName))
            {
                throw new ArgumentException("Model cannot be empty, null or with less than 3 symbols.");
            }
        }

        private void ValidateMaterialType(MaterialType type)
        {
            if (type.Equals(null))
            {
                throw new ArgumentNullException("Invalid type");
            }
        }

    }
}
