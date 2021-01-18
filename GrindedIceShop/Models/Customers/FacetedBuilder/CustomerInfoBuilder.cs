namespace GrindedIceShop.Models.Customers.FacetedBuilder
{
    public class CustomerInfoBuilder : CustomerBuilderFacade
    {
        public CustomerInfoBuilder(Customer customer)
        {
            Customer = customer;
        }

        public CustomerInfoBuilder WithName(string name)
        {
            Customer.Name = name;
            return this;
        }

        public CustomerInfoBuilder WithPhoneNumber(string phoneNumber)
        {
            Customer.PhoneNumeber = phoneNumber;
            return this;
        }
    }
}
