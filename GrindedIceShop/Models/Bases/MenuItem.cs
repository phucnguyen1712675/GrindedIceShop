using GrindedIceShop.Models.Toppings;
using PropertyChanged;

namespace GrindedIceShop.Models.Bases
{
    [AddINotifyPropertyChangedInterface]
    public abstract class MenuItem
    {
        public int MEnuItemID { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public virtual decimal GetPrice() { return 0; }

        public virtual string Prepare()
        {
            return Name;
        }

        public MenuItem AddToppingToItem(string topping)
        {
            return ToppingManager.Instance.AddToppingToItem(this, topping);
        }

        public MenuItem Clone() { return this; }

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
