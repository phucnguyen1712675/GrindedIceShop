using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrindedIceShop.Models.Beverages.BeverageTypes
{
    class BeverageTypeManager
    {
        private Dictionary<string, BeverageType> BeverageTypes;

        private static BeverageTypeManager instance;
        public static BeverageTypeManager Instance
        {
            get
            {
                if (instance == null)
                    new BeverageTypeManager();
                return instance;
            }
        }

        private BeverageTypeManager()
        {
            BeverageTypes = new Dictionary<string, BeverageType>();
            BeverageTypes.Add("Hot", new HotBeverage());
            BeverageTypes.Add("Cold", new ColdBeverage());
            instance = this;
        }

        public BeverageType GetBeverageType(string type)
        {
            if (type != null)
            {
                string NormalizedNameType = type.Replace(" ", "");
                if (BeverageTypes.ContainsKey(NormalizedNameType))
                {
                    return BeverageTypes[NormalizedNameType].Clone();
                }
            }
            return RecruitDefaultType();
        }

        private BeverageType RecruitDefaultType()
        {
            return BeverageTypes["Hot"].Clone();
        }
    }
}
