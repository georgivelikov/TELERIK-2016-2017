using System;

namespace ChainOfResponsibility
{
    public class Ceo : BankEmployee
    {
        public override void ApproveLoan(decimal amount)
        {
            if (amount < 10000000)
            {
                Console.WriteLine("I, bank CEO, approve this loan");
            }
            else
            {
                Console.WriteLine("You are not approved for loan");
            }
        }
    }
}
