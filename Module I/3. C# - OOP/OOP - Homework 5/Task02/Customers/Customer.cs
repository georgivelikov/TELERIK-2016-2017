namespace Task02.Customers
{
    using Enumerations;

    public class Customer
    {
        private CustomerType type;

        public Customer(CustomerType type)
        {
            this.type = type;
        }

        public CustomerType Type
        {
            get
            {
                return this.type;
            }

            private set
            {
                this.type = value;
            }
        }
    }
}
