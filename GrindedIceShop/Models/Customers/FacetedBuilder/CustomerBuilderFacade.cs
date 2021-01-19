namespace GrindedIceShop.Models.Customers.FacetedBuilder
{
    public class CustomerBuilderFacade
    {
        protected Customer Customer { get; set; }

        public CustomerBuilderFacade() => Customer = new Customer();
        public Customer Build() => Customer;

        public CustomerInfoBuilder Info => new CustomerInfoBuilder(Customer);
        public CustomerAccountBuilder Account => new CustomerAccountBuilder(Customer);
        public CustomerAddressBuilder Address => new CustomerAddressBuilder(Customer);
    }
}
