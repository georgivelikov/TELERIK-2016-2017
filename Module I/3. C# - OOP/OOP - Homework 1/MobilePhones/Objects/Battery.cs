namespace MobilePhones.Objects
{
    using System;
    using System.Text;

    using MobilePhones.Enums;

    public class Battery
    {
        private const double DefaultHoursIdle = 24;
        private const double DefaultHoursTalk = 12;
        private const int Interval = 4;

        private string model;
        private double hoursIdle;
        private double hoursTalk;
        private BatteryType batteryType;

        public Battery(string model, BatteryType batteryType)
            : this(model, DefaultHoursIdle, DefaultHoursTalk, batteryType)
        {
        }

        public Battery(string model, double hoursIdle, double hoursTalk, BatteryType batteryType)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.BatteryType = batteryType;
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                if (value.Length < 5)
                {
                    throw new ArgumentException("Model name should be more descriptive!");
                }

                this.model = value;
            }
        }

        public double HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Value should be possitive number!");
                }

                this.hoursIdle = value;
            }
        }

        public double HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Value should be possitive number!");
                }
                if (value >= this.HoursIdle)
                {
                    throw new ArgumentException("Hours Talk should be less than Hours Idle!");
                }

                this.hoursTalk = value;
            }
        }

        public BatteryType BatteryType
        {
            get
            {
                return this.batteryType;
            }

            set
            {
                this.batteryType = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Battery Information:" + Environment.NewLine);
            sb.AppendFormat(new string(' ', Interval) + "Model: {0}" + Environment.NewLine, this.Model);
            sb.AppendFormat(new string(' ', Interval) + "Stand-by time: Up to {0} h" + Environment.NewLine, this.HoursIdle);
            sb.AppendFormat(new string(' ', Interval) + "Talk time: Up to {0} h" + Environment.NewLine, this.HoursTalk);
            sb.AppendFormat(new string(' ', Interval) + "Battery Type: {0}" + Environment.NewLine, this.BatteryType);
            return sb.ToString();

        }
    }
}
