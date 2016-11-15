namespace ChainOfResponsibility
{
    public abstract class BankEmployee
    {
        public BankEmployee Manager { get; set; }

        public abstract void ApproveLoan(decimal amount);
    }
}
