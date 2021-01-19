using GrindedIceShop.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrindedIceShop.Models.Toppings.SubToppings
{
    class EggPudding : Topping
    {
        public EggPudding(MenuItem item) : base(item)
        {
            Name = "Egg Pudding";
            Price = 15000;
        }
    }
}
