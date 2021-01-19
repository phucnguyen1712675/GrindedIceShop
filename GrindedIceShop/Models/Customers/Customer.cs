using PropertyChanged;

namespace GrindedIceShop.Models.Customers
{
    [AddINotifyPropertyChangedInterface]
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public string Email { get; set; }
        public int Point { get; set; }

        public string City { get; set; }
        public string Address { get; set; }

        public override string ToString() => $"Name: {Name}, Phone number: {PhoneNumber}, Email: {Email} Point: {Point}, City: {City}, Address: {Address}";

        public Customer ShallowCopy() => (Customer)this.MemberwiseClone();

        public Customer DeepCopy()
        {
            var clone = (Customer)this.MemberwiseClone();
            clone.Name = string.Copy(Name);
            clone.PhoneNumber = string.Copy(PhoneNumber);
            clone.Email = string.Copy(Email);
            clone.City = string.Copy(City);
            clone.Address = string.Copy(Address);
            return clone;
        }

        public void IncreasePoint(int amount)
        {
            Point += amount;
            //Console.WriteLine($"The price for the {Name} has been increased by {amount}$.");
        }
        public bool DecreasePoint(int amount)
        {
            if (amount < Point)
            {
                Point -= amount;
                //Console.WriteLine($"The price for the {Name} has been decreased by {amount}$.");
                return true;
            }
            return false;
        }
    }
}
