namespace MusicShop.Models
{
    using System;
    using System.Text;

    using MusicShopManager.Interfaces;

    public abstract class Guitar : Instrument, IGuitar
    {
        private const int DefaultNumberOfStrings = 6;

        private string bodyWood;
        private string fingerboardWood;

        public Guitar(string make, string model, decimal price, string color, bool isElectronic, string bodyWood, string fingerboardWood)
            : base(make, model, price, color, isElectronic)
        {
            this.BodyWood = bodyWood;
            this.FingerboardWood = fingerboardWood;
        }

        public string BodyWood
        {
            get
            {
                return this.bodyWood;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Must have body wood");
                }

                this.bodyWood = value;
            }
        }

        public string FingerboardWood
        {
            get
            {
                return this.fingerboardWood;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Must have fingerboard wood");
                }

                this.fingerboardWood = value;
            }
        }

        public virtual int NumberOfStrings
        {
            get
            {
                return Guitar.DefaultNumberOfStrings;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendFormat("Strings: {0}\n", this.NumberOfStrings);
            sb.AppendFormat("Body wood: {0}\n", this.BodyWood);
            sb.AppendFormat("Fingerboard wood: {0}\n", this.FingerboardWood);

            return sb.ToString().Trim();
        }
    }
}
