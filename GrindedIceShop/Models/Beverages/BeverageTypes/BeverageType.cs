using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrindedIceShop.Models.Beverages.BeverageTypes
{
    public abstract class BeverageType
    {
        public string Prepare(char size)
        {
            string result = "";
            result += TakeCup(size) +",";
            result += PrepareBase() + ",";
            result += AddDrink() + ",";
            result += AddTools();
            return result;
        }

        public virtual string TakeCup(char size)
        {
            return " Take Cup size " + size.ToString().ToUpper();
        }

        public virtual string PrepareBase()
        {
            return "";
        }

        public virtual string AddDrink()
        {
            return " Pour drink to cup";
        }

        public virtual string AddTools()
        {
            return " Add straw and spoon";
        }

        public abstract BeverageType Clone();
    }
}
