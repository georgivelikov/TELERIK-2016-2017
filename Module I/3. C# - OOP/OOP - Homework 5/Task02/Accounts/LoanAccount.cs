namespace Task02.Accounts
{
    using System;

    using Task02.Customers;
    using Task02.Enumerations;
    using Task02.Interfaces;

    public class LoanAccount : Account, IDepositAccount
    {
        private const int MinMonthsForIndividuals = 3;
        private const int MinMonthsForCompanies = 2;

        public LoanAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public void DepositMoney(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be positive number!");
            }

            this.Balance += amount;
        }

        public override decimal CalculateInterest(int months)
        {
            if (this.Customer.Type == CustomerType.Company)
            {
                if (months <= MinMonthsForCompanies)
                {
                    return 0;
                }
                else
                {
                    return base.CalculateInterest(months);
                }
            }
            else
            {
                if (months <= MinMonthsForIndividuals)
                {
                    return 0;
                }
                else
                {
                    return base.CalculateInterest(months);
                }
            }
        }
    }
}
