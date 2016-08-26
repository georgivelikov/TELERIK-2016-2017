namespace MobilePhones.Objects
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    using MobilePhones.Enums;

    public class GSM
    {
        private const decimal DefaultPrice = 600;
        private const string DefaultOwner = "Unknown Unknown";
        private const decimal PricePerMinute = 0.37m;

        private static GSM iPhone4S = new GSM(
            "IPhone 4s",
            "Apple",
            299.99m,
            "Steve Jobs",
            new Battery("Non-removable Apple Battery", 200, 14, BatteryType.Li_Po),
            new Display(3.5, 16000000));

        private string model;
        private string manufacturer;
        private decimal price;
        private string owner;
        private Battery battery;
        private Display display;
        private List<Call> callHistory;

        public GSM(string model, string manufacturer)
            : this(model, manufacturer, DefaultPrice, DefaultOwner, null, null)
        {
        }

        public GSM(string model, string manufacturer, decimal price, string owner, Battery battery, Display display)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.Battery = battery;
            this.Display = display;
            this.callHistory = new List<Call>();
        }

        public static GSM IPhone4S
        {
            get
            {
                return iPhone4S;
            }

            set
            {
                iPhone4S = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                if (value.Length < 5 || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Model name should be more descriptive!");
                }

                this.model = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }

            set
            {
                if (value.Length < 5 || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Manufacturer name should be more descriptive!");
                }

                this.manufacturer = value;
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
                    throw new ArgumentException("Price should be possitve number!");
                }

                this.price = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }

            set
            {
                Regex regex = new Regex("[A-Z][a-z]+\\s[A-Z][a-z]+");

                if (regex.IsMatch(value))
                {
                    this.owner = value;
                }
                else
                {
                    throw new ArgumentException("Owner name should be in the format: \"Firstname Lastname\"");
                }
            }
        }

        public Battery Battery
        {
            get
            {
                return this.battery;
            }

            set
            {
                this.battery = value;
            }
        }

        public Display Display
        {
            get
            {
                return this.display;
            }

            set
            {
                this.display = value;
            }
        }

        public IEnumerable<Call> CallHistory
        {
            get
            {
                return this.callHistory;
            }
        }

        public void AddCall(Call call)
        {
            this.callHistory.Add(call);
        }

        public void DeleteCall(Call call)
        {
            this.callHistory.Remove(call);
        }

        public decimal CalculateTotalPrice()
        {
            decimal result = 0;

            foreach (var call in this.callHistory)
            {
                result += (decimal)call.Duration * PricePerMinute / 60;
            }

            return result;
        }

        public void ClearHistory()
        {
            this.callHistory.Clear();
        }

        public string PrintCallHistory()
        {
            if (this.callHistory.Count == 0)
            {
                return "Call History: \nEmpty";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Call History:");
                foreach (var call in this.callHistory)
                {
                    sb.AppendLine(call.ToString());
                }

                return sb.ToString().Trim();
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Model: {0}" + Environment.NewLine, this.Model);
            sb.AppendFormat("Manufacturer: {0}" + Environment.NewLine, this.Manufacturer);
            sb.AppendFormat("Price: {0:0.00}$" + Environment.NewLine, this.Price);
            sb.AppendFormat("Owner: {0}" + Environment.NewLine, this.Owner);
            sb.AppendFormat(this.Battery.ToString());
            sb.AppendFormat(this.Display.ToString());

            return sb.ToString().Trim();
        }
    }
}
