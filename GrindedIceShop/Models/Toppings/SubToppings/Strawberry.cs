using GrindedIceShop.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrindedIceShop.Models.Toppings.SubToppings
{
    class Strawberry: Topping
    {
        public Strawberry(MenuItem item) : base(item) {
            Name = "Strawberry";
            Price = 20000;
        }

    }
}
