using GrindedIceShop.Models.SupportCompareStrings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrindedIceShop.Models.SizeManagers
{
    class SizeManager
    {
        public Dictionary<char, decimal> SizePriceManager { get; set; }

        public decimal GetUpSizePrice(char c) {
            c = SizePriceManager.Keys.ToList().FirstOrDefault(item => new MyCompareString().CompareChar(item, c));
            if (SizePriceManager.ContainsKey(c))
                return SizePriceManager[c];
            return 0;
        }
    }
}
