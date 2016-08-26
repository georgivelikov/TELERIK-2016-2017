namespace Task_02
{
    using System;

    public class Worker : Human
    {
        private const int WorkDaysInWeek = 5; // we assume that worker does not work in Sathurday and Sunday
        private decimal weekSalary;
        private int workHoursPerDay;


        public Worker(string firstName, string lastName, decimal weekSalary, int workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary
        {
            get
            {
                return this.weekSalary;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Week salary mustbe possitve!");
                }

                this.weekSalary = value;
            }
        }

        public int WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }

            set
            {
                if (value < 0 || value > 16)
                {
                    throw new ArgumentException("Work hours must be between 0 and 16!");
                }

                this.workHoursPerDay = value;
            }
        }

        public decimal MoneyPerHour()
        {
            decimal result = this.WeekSalary / (this.WorkHoursPerDay * WorkDaysInWeek);

            return result;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(" | money per hour: {0:0.00}$", this.MoneyPerHour());
        }
    }
}
