using PropertyChanged;

namespace GrindedIceShop.Models.Beverages
{
    [AddINotifyPropertyChangedInterface]
    public abstract class Beverage
    {
        public int BeverageId { get; set; }
        public int BeverageName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public abstract void PrepareBererage();

        public void IncreasePrice(decimal amount)
        {
            Price += amount;
            //Console.WriteLine($"The price for the {Name} has been increased by {amount}$.");
        }
        public bool DecreasePrice(decimal amount)
        {
            if (amount < Price)
            {
                Price -= amount;
                //Console.WriteLine($"The price for the {Name} has been decreased by {amount}$.");
                return true;
            }
            return false;
        }
    }
}
