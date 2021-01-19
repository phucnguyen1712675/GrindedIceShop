using GrindedIceShop.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrindedIceShop.Models.Toppings
{
    public abstract class ToppingDecorator : MenuItem
    {
        protected MenuItem item { get; set; }

        public ToppingDecorator(MenuItem item)
        {
            this.item = item;
        }

        public override string Prepare()
        {
            string result = "";
            if(item!= null)
                result = item.Prepare();
            return result;
        }

        public override decimal GetPrice()
        {
            decimal result = 0;
            if(item!= null)
                result= item.GetPrice();
            return result;
        }
    }
}
