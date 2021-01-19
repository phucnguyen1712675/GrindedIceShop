using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrindedIceShop.Models.GrindedIces.SubGrindedIces
{
    class ChocolateGrindedIce: GrindedIce
    {
        public ChocolateGrindedIce() {
            Price = 35000;
            Name = "Chocolate Grinded Ice";
        }

        public override decimal GetPrice()
        {
            return Price + GetUpSizePrice();
        }

    }
}
