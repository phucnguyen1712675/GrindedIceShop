using GrindedIceShop.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrindedIceShop.Models.Toppings.SubToppings
{
    class Flan : Topping
    {
        public Flan(MenuItem item) : base(item) {
            Name = "Flan";
            Price= 15000;
        }
    }
}
