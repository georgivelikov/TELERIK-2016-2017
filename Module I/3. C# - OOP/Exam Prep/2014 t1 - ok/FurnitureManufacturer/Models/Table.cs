namespace FurnitureManufacturer.Models
{
    using System;

    using FurnitureManufacturer.Interfaces;

    public class Table : Furniture, ITable
    {
        private readonly decimal length;
        private readonly decimal width;

        public Table(string model, MaterialType material, decimal price, decimal height, decimal length, decimal width)
            : base(model, material, price, height)
        {
            this.ValidateTableLenght(length);
            this.ValidateTableWidth(width);

            this.length = length;
            this.width = width;
        }

        public decimal Length
        {
            get
            {
                return this.length;
            }
        }

        public decimal Width
        {
            get
            {
                return this.width;
            }
        }

        public decimal Area
        {
            get
            {
                return this.width * this.length;
            }
        }

        public override string ToString()
        {
            string result = string.Format(
                "{0}, Length: {1}, Width: {2}, Area: {3}",
                base.ToString(),
                this.Length,
                this.Width,
                this.Area);

            return result;
        }

        private void ValidateTableWidth(decimal tableWidth)
        {
            if (tableWidth <= 0)
            {
                throw new ArgumentException("Ivalid width");
            }
        }

        private void ValidateTableLenght(decimal tableLenght)
        {
            if (tableLenght <= 0)
            {
                throw new ArgumentException("Ivalid lenght");
            }
        }
    }
}
