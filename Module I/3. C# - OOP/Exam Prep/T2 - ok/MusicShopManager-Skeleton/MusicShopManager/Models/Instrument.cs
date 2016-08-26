namespace MusicShop.Models
{
    using System;
    using System.Text;

    using MusicShopManager.Interfaces;

    public abstract class Instrument : Article, IInstrument
    {
        private string color;
        private bool isElectronic;

        public Instrument(string make, string model, decimal price, string color, bool isElectronic)
            : base(make, model, price)
        {
            this.Color = color;
            this.isElectronic = isElectronic;
        }

        public string Color
        {
            get
            {
                return this.color;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Must have color");
                }

                this.color = value;
            }
        }

        public bool IsElectronic
        {
            get
            {
                return this.isElectronic;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendFormat("Color: {0}\n", this.Color);
            sb.AppendFormat("Electronic: {0}\n", this.IsElectronic ? "yes" : "no");

            return sb.ToString().Trim();
        }
    }
}
