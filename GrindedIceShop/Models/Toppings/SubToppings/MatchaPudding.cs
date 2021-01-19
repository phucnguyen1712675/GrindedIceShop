using GrindedIceShop.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrindedIceShop.Models.Toppings.SubToppings
{
    class MatchaPudding : Topping
    {
        public MatchaPudding(MenuItem item) : base(item)
        {
            Name = "Matcha Pudding";
            Price = 13000;
        }

    }
}
