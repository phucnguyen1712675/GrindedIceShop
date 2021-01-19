using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public virtual string Prepare() {
            return Name;
        }

        public MenuItem AddToppingToItem(string topping)
        {
            return ToppingManager.Instance.AddToppingToItem(this, topping);
        }

        public MenuItem Clone() { return this; }
    }
}
