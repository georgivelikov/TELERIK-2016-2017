namespace Task02
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Accounts;

    using Customers;

    using Enumerations;

    public class Program
    {
        public static void Main()
        {
            DepositAccount depositAcc = new DepositAccount(new Customer(CustomerType.Company), 1000m, 5.7m);
            LoanAccount loanAcc = new LoanAccount(new Customer(CustomerType.Individual), 5000m, 7m);
            MortgageAccount mortgageAcc = new MortgageAccount(new Customer(CustomerType.Individual), 100000m, 5m);

            Console.WriteLine(depositAcc.CalculateInterest(2) + "%");
            Console.WriteLine(loanAcc.CalculateInterest(24) + "%");
            Console.WriteLine(mortgageAcc.CalculateInterest(15) + "%");

            depositAcc.WithdrawMoney(200m);
            Console.WriteLine(depositAcc.Balance);

            loanAcc.DepositMoney(900m);
            Console.WriteLine(loanAcc.Balance);
        }
    }
}
