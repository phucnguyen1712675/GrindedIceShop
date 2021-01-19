using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrindedIceShop.Models.Beverages.SubBeverages
{
    class MilkTea : Beverage
    {
        public MilkTea()
        {
            Name = "Milk tea";
            Price = 20000;
        }

        public override decimal GetPrice()
        {
            return Price + GetUpSizePrice();
        }
    }
}
