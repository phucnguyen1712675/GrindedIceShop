namespace GrindedIceShop.Models.Customers.FacetedBuilder
{
    public class CustomerInfoBuilder : CustomerBuilderFacade
    {
        private static int _nextId;

        static CustomerInfoBuilder()
        {
            _nextId = 0;
        }

        public CustomerInfoBuilder(Customer customer)
        {
            Customer = customer;
            this.SetId();
        }

        private void SetId() => Customer.CustomerId = _nextId++;

        public CustomerInfoBuilder WithName(string name)
        {
            Customer.Name = name;
            return this;
        }

        public CustomerInfoBuilder WithPhoneNumber(string phoneNumber)
        {
            Customer.PhoneNumber = phoneNumber;
            return this;
        }
    }
}
