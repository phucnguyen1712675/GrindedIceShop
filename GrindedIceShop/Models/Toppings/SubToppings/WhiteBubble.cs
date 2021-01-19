using GrindedIceShop.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrindedIceShop.Models.Toppings.SubToppings
{
    class WhiteBubble : Topping
    {
        public WhiteBubble(MenuItem item) : base(item)
        {
            Name = "Flan";
            Price = 8000;
        }
    }
}
