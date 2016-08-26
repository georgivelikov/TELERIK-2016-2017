namespace Task02.Accounts
{
    using System;

    using Task02.Customers;
    using Task02.Interfaces;

    public class DepositAccount : Account, IWithdrawAccount, IDepositAccount
    {
        public DepositAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override decimal CalculateInterest(int months)
        {
            if (months <= 0)
            {
                throw new ArgumentException("Months must be positive number!");
            }

            if (this.Balance > 0 && this.Balance < 1000)
            {
                return 0;
            }
            else
            {
                return base.CalculateInterest(months);
            }
        }

        public void WithdrawMoney(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be positive number!");
            }

            this.Balance -= amount;
        }

        public void DepositMoney(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be positive number!");
            }

            this.Balance += amount;
        }
    }
}
