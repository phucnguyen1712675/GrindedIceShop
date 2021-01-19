using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrindedIceShop.Models.SizeManagers
{
    class GrindedIceSizeManager : SizeManager
    {
        private static GrindedIceSizeManager instance;

        public static GrindedIceSizeManager Instance
        {
            get
            {
                if (instance == null)
                    new GrindedIceSizeManager();
                return instance;
            }
        }

        private GrindedIceSizeManager()
        {
            SizePriceManager = new Dictionary<char, decimal>();

            SizePriceManager.Add('S', 10000);
            SizePriceManager.Add('M', 20000);
            SizePriceManager.Add('L', 25000);
            instance = this;
        }
    }
}
