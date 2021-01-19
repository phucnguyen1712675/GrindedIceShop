using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrindedIceShop.Models.GrindedIces.SubGrindedIces
{
    class MiloGrindedIce : GrindedIce
    {
        public MiloGrindedIce() {
            Name = "Milo Grinded Ice ";
            Price = 30000;
        }

        public override decimal GetPrice()
        {
            return Price + GetUpSizePrice();
        }
    }
}
