using GrindedIceShop.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrindedIceShop.Models.Toppings
{
    public class Topping : ToppingDecorator
    {
        public Topping(MenuItem item): base(item) { }

        public override string Prepare()
        {
            return base.Prepare() + GetSubToppingName();
        }

        public override decimal GetPrice()
        {
            return base.GetPrice() + GetSubToppingPrice();
        }

        public virtual decimal GetSubToppingPrice()
        {
            return Price;
        }

        public virtual string GetSubToppingName()
        {
            if (string.IsNullOrEmpty(Name))
                return "";
            return " (" + Name + ")";
        }
    }
}
