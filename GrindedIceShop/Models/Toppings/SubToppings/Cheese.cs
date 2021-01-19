using GrindedIceShop.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrindedIceShop.Models.Toppings.SubToppings
{
    class Cheese : Topping
    {
        public Cheese(MenuItem item) : base(item) {
            Name = "Cheese";
            Price = 10000;
        }
    }
}
