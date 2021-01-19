using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrindedIceShop.Models.SizeManagers
{
    class BeverageSizeManager: SizeManager
    {
        private static BeverageSizeManager instance;
        public static BeverageSizeManager Instance
        {
            get
            {
                if (instance == null)
                    new BeverageSizeManager();
                return instance;
            }
        }

        private BeverageSizeManager()
        {
            SizePriceManager = new Dictionary<char, decimal>();
            SizePriceManager.Add('S', 5000);
            SizePriceManager.Add('M', 10000);
            SizePriceManager.Add('L', 15000);
            instance = this;
        }
    }
}
