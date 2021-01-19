using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrindedIceShop.Models.Beverages.SubBeverages
{
    class Tea : Beverage
    {
        public Tea() {
            Name = "Tea";
            Price = 15000;
        }

        public override decimal GetPrice()
        {
            return Price + GetUpSizePrice();
        }
    }
}
