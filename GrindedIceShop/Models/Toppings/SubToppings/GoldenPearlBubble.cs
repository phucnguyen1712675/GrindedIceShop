using GrindedIceShop.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrindedIceShop.Models.Toppings.SubToppings
{
    class GoldenPearlBubble:Topping
    {
        public GoldenPearlBubble(MenuItem item) : base(item)
        {
            Name = "Golden Pearl Bubble";
            Price = 10000;
        }
    }
}
