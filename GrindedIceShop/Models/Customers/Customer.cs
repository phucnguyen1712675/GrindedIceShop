using PropertyChanged;

namespace GrindedIceShop.Models.Customers
{
    [AddINotifyPropertyChangedInterface]
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string PhoneNumeber { get; set; }

        public string Email { get; set; }
        public int Point { get; set; }

        public string City { get; set; }
        public string Address { get; set; }

        public override string ToString() => $"Name: {Name}, Phone number: {PhoneNumeber}, Email: {Email} Point: {Point}, City: {City}, Address: {Address}";
    }
}
