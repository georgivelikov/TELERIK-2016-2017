using System;

namespace ChainOfResponsibility
{
    public class BranchManager : BankEmployee
    {
        public BranchManager()
        {
        }

        public override void ApproveLoan(decimal amount)
        {
            if (amount < 100000m)
            {
                Console.WriteLine("I, branch manager, approve this loan");
            }
            else
            {
                this.Manager.ApproveLoan(amount);
            }
        }
    }
}
