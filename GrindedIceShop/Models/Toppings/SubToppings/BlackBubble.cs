using GrindedIceShop.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrindedIceShop.Models.Toppings.SubToppings
{
    class BlackBubble : Topping
    {
        public BlackBubble(MenuItem item) : base(item)
        {
            Name = "Black bubble";
            Price = 5000;
        }
    }
}
