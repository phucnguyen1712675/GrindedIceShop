using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrindedIceShop.Models.Beverages.BeverageTypes
{
    class HotBeverage : BeverageType
    {
        public override string PrepareBase()
        {
            return " Prepare hot water";
        }

        public override BeverageType Clone()
        {
            return new HotBeverage();
        }
    }
}
