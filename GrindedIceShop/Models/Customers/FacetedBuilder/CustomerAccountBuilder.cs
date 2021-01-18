namespace GrindedIceShop.Models.Customers.FacetedBuilder
{
    public class CustomerAccountBuilder : CustomerBuilderFacade
    {
        public CustomerAccountBuilder(Customer customer)
        {
            Customer = customer;
        }

        public CustomerAccountBuilder WithEmail(string email)
        {
            Customer.Email = email;
            return this;
        }

        public CustomerAccountBuilder WithPoint(int point)
        {
            Customer.Point = point;
            return this;
        }
    }
}
