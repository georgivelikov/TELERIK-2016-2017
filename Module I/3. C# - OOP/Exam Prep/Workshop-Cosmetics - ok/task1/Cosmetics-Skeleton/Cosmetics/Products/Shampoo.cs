namespace Cosmetics.Products
{
    using System.Text;

    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public class Shampoo : Product, IShampoo
    {
        private UsageType usage;
        private uint milliliters;

        private decimal priceInMil;

        public Shampoo(string name, string brand, decimal price, GenderType genger, UsageType usage, uint milliliters)
            : base(name, brand, price, genger)
        {
            this.priceInMil = price;
            this.Usage = usage;
            this.Milliliters = milliliters;
        }

        public UsageType Usage
        {
            get
            {
                return this.usage;
            }
            set
            {
                this.usage = value;
            }
        }

        public override decimal Price
        {
            get
            {
                return this.priceInMil * this.Milliliters;
            }


        }

        public uint Milliliters
        {
            get
            {
                return this.milliliters;
            }
            set
            {
                this.milliliters = value;
            }
        }

        public override string Print()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.Print());
            sb.AppendLine(string.Format(" * Quantity: {0} ml", this.Milliliters));
            sb.AppendLine(string.Format(" * Usage: {0}", this.Usage));

            return sb.ToString().Trim();
        }
    }
}
