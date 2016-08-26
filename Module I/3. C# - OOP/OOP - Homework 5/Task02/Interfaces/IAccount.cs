namespace Task02.Interfaces
{
    using Task02.Customers;

    public interface IAccount
    {
        Customer Customer { get; set; }

        decimal Balance { get; set; }

        decimal InterestRate { get; set; }

        decimal CalculateInterest(int months);
    }
}
