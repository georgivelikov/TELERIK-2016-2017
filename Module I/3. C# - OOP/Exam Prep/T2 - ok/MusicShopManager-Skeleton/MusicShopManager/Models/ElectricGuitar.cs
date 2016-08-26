namespace MusicShop.Models
{
    using System;
    using System.Text;

    using MusicShopManager.Interfaces;

    public class ElectricGuitar : Guitar, IElectricGuitar
    {
        private int numberOfAdapters;
        private int numberOfFrets;

        public ElectricGuitar(string make, string model, decimal price, string color, bool isElectronic, string bodyWood, string fingerboardWood, int numberOfAdapters, int numberOfFrets)
            : base(make, model, price, color, isElectronic, bodyWood, fingerboardWood)
        {
            this.NumberOfAdapters = numberOfAdapters;
            this.NumberOfFrets = numberOfFrets;
        }

        public int NumberOfAdapters
        {
            get
            {
                return this.numberOfAdapters;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Must be non-negative");
                }

                this.numberOfAdapters = value;
            }
        }

        public int NumberOfFrets
        {
            get
            {
                return this.numberOfFrets;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Must be positive");
                }

                this.numberOfFrets = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendFormat("Adapters: {0}\n", this.NumberOfAdapters);
            sb.AppendFormat("Frets: {0}\n", this.NumberOfFrets);

            return sb.ToString().Trim();
        }
    }
}
