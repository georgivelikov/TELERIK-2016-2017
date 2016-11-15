using System;

namespace ChainOfResponsibility
{
    public class LoanSupervisor : BankEmployee
    {
        public LoanSupervisor()
        {
        }
        public override void ApproveLoan(decimal amount)
        {
            if (amount < 1000000)
            {
                Console.WriteLine("I, load supervisor, approve this loan");
            }
            else
            {
                this.Manager.ApproveLoan(amount);
            }
        }
    }
}
