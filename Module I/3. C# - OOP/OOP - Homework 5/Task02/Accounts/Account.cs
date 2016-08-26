namespace Task02.Accounts
{
    using System;

    using Task02.Customers;
    using Task02.Interfaces;

    public abstract class Account : IAccount
    {
        private Customer customer;
        private decimal balance;
        private decimal interestRate;

        public Account(Customer customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }


        public Customer Customer
        {
            get
            {
                return this.customer;
            }

            set
            {
                this.customer = value;
            }
        }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }

            set
            {
                this.balance = value;
            }
        }

        public decimal InterestRate
        {
            get
            {
                return this.interestRate;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Interest rates can not be negative, unless you are the Swiss National Bank!");
                }

                this.interestRate = value;
            }
        }

        public virtual decimal CalculateInterest(int months)
        {
            return (this.InterestRate * months) / 100;
        }
    }
}
