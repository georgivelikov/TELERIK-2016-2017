namespace Task02.Accounts
{
    using Task02.Customers;
    using Task02.Enumerations;
    using Task02.Interfaces;

    public class MortgageAccount : Account, IDepositAccount
    {
        public const int MonthsWithNoInterestForIndividuals = 6;
        public const int MonthsWithHalfInterestForCompanies = 12;

        public MortgageAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override decimal CalculateInterest(int months)
        {
            if (this.Customer.Type == CustomerType.Company)
            {
                if (months <= MonthsWithHalfInterestForCompanies)
                {
                    return base.CalculateInterest(months) * 0.5m;
                }
                else
                {
                    return base.CalculateInterest(months);
                }
            }
            else
            {
                if (months <= MonthsWithNoInterestForIndividuals)
                {
                    return base.CalculateInterest(months) * 0.5m;
                }
                else
                {
                    return base.CalculateInterest(months);
                }
            }
        }

        public void DepositMoney(decimal amount)
        {
            this.Balance += amount;
        }
    }
}
