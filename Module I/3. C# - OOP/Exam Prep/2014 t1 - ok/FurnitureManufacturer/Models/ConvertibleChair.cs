namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;

    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private const bool ConvertedStart = false;
        private const decimal ConvertedHeight = 0.1m;
        private readonly decimal initialHeigth;

        public ConvertibleChair(string model, MaterialType material, decimal price, decimal height, int numberOfLegs)
            : base(model, material, price, height, numberOfLegs)
        {
            this.IsConverted = ConvertedStart;
            this.initialHeigth = height;
        }

        public bool IsConverted { get; private set; }

        public void Convert()
        {
            if (this.IsConverted)
            {
                this.IsConverted = false;
                this.Height = this.initialHeigth;
            }
            else
            {
                this.IsConverted = true;
                this.Height = ConvertedHeight;
            }
        }

        public override string ToString()
        {
            string result = string.Format("{0}, State: {1}", base.ToString(), this.IsConverted ? "Converted" : "Normal");
            return result;
        }
    }
}
