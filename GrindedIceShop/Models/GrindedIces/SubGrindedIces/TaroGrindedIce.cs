using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrindedIceShop.Models.GrindedIces.SubGrindedIces
{
    class TaroGrindedIce : GrindedIce
    {
        public TaroGrindedIce() {
            Price = 38000;
            Name = "Taro Grinded Ice ";
        }

        public override decimal GetPrice()
        {
            return Price + GetUpSizePrice();
        }
    }
}
