namespace GrindedIceShop.Models.Customers.FacetedBuilder
{
    public class CustomerBuilderFacade
    {
        private static int nextId;
        protected Customer Customer { get; set; }

        static CustomerBuilderFacade()
        {
            nextId = 0;
        }

        public CustomerBuilderFacade()
        {
            Customer = new Customer
            {
                CustomerId = nextId++
            };
        }

        public Customer Build() => Customer;

        public CustomerInfoBuilder Info => new CustomerInfoBuilder(Customer);
        public CustomerAccountBuilder Account => new CustomerAccountBuilder(Customer);
        public CustomerAddressBuilder Address => new CustomerAddressBuilder(Customer);
    }
}
