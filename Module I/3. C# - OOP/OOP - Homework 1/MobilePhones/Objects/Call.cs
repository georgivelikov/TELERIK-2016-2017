namespace MobilePhones.Objects
{
    using System;
    using System.Text;

    public class Call
    {
        private DateTime date;
        private string phoneNumber;
        private double duration;

        public Call(DateTime date, string phoneNumber, double duration)
        {
            this.DateAndTime = date;
            this.Date = date.ToLongDateString();
            this.Time = date.ToLongTimeString();
            this.PhoneNumber = phoneNumber;
            this.Duration = duration;
        }

        public DateTime DateAndTime { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public string PhoneNumber { get; set; }

        public double Duration { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Number: {0}" + Environment.NewLine, this.PhoneNumber);
            sb.AppendFormat("Date: {0} at {1}" + Environment.NewLine, this.Date, this.Time);
            sb.AppendFormat("Duration: {0} seconds" + Environment.NewLine, this.Duration);

            return sb.ToString();
        }
    }
}
