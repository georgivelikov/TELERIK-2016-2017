namespace FurnitureManufacturer.Models
{
    using System;

    using FurnitureManufacturer.Interfaces;

    public class Chair : Furniture, IChair
    {
        private readonly int numberOfLegs;

        public Chair(string model, MaterialType material, decimal price, decimal height, int numberOfLegs)
            : base(model, material, price, height)
        {
            this.ValidateNumberOfLegs(numberOfLegs);

            this.numberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs
        {
            get
            {
                return this.numberOfLegs;
            }
        }

        public override string ToString()
        {
            string result = string.Format("{0}, Legs: {1}", base.ToString(), this.NumberOfLegs);

            return result;
        }

        private void ValidateNumberOfLegs(int chairLegs)
        {
            if (chairLegs < 0)
            {
                throw new ArgumentException("Chair legs can not be less than 0");
            }
        }
    }
}
