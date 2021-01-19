using GrindedIceShop.Models.Bases;
using GrindedIceShop.Models.Beverages.BeverageTypes;
using GrindedIceShop.Models.SizeManagers;
using PropertyChanged;

namespace GrindedIceShop.Models.Beverages
{
    [AddINotifyPropertyChangedInterface]
    public abstract class Beverage : MainMenuItem
    {
        public BeverageType BeverageType { get; set; }

        public void SetType(string type)
        {
            BeverageType = BeverageTypeManager.Instance.GetBeverageType(type);
        }

        public override decimal GetUpSizePrice()
        {
            return BeverageSizeManager.Instance.GetUpSizePrice(Size);
        }

        public override string Prepare()
        {
            string result;
            result = Name+ " ";
            result += "("+ BeverageType.Prepare(Size) + ") ";
            return result;
        }

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
