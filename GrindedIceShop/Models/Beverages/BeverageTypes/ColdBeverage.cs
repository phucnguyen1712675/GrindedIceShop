using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrindedIceShop.Models.Beverages.BeverageTypes
{
    class ColdBeverage : BeverageType
    {
        public override string PrepareBase()
        {
            return " Add Ice";
        }

        public override BeverageType Clone()
        {
            return new ColdBeverage();
        }
    }
}
