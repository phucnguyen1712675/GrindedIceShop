namespace GrindedIceShop.Models.Customers.FacetedBuilder
{
    public class CustomerAddressBuilder : CustomerBuilderFacade
    {
        public CustomerAddressBuilder(Customer customer)
        {
            Customer = customer;
        }

        public CustomerAddressBuilder InCity(string city)
        {
            Customer.City = city;
            return this;
        }

        public CustomerAddressBuilder AtAddress(string address)
        {
            Customer.Address = address;
            return this;
        }
    }
}
