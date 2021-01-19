using GrindedIceShop.Models.Bases;
using GrindedIceShop.Models.Beverages.SubBeverages;
using GrindedIceShop.Models.GrindedIces;
using GrindedIceShop.Models.GrindedIces.SubGrindedIces;
using GrindedIceShop.Models.SupportCompareStrings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrindedIceShop.Models.ShopHome
{
    class GrindedIceMenuItemManager
    {
        private static GrindedIceMenuItemManager instance;
        public static GrindedIceMenuItemManager Instance
        {
            get
            {
                if (instance == null)
                    new GrindedIceMenuItemManager();
                return instance;
            }
        }

        public Dictionary<string, GrindedIce> GrindedIceMenuItems { get; set; }
        private GrindedIceMenuItemManager()
        {
            GrindedIceMenuItems = new Dictionary<string, GrindedIce>();
            GrindedIceMenuItems.Add("Chocolate Grinded Ice", new ChocolateGrindedIce());
            GrindedIceMenuItems.Add("Milo Grinded Ice", new MiloGrindedIce());
            GrindedIceMenuItems.Add("Taro Grinded Ice", new TaroGrindedIce());
            instance = this;
        }

        public List<string> GetGrindedIceMenuItemsName()
        {
            return GrindedIceMenuItems.Keys.ToList();
        }

        public GrindedIce GetGrindedIceMenuItem(string name)
        {
            name = GrindedIceMenuItems.Keys.ToList().FirstOrDefault(item => new MyCompareString().CompareString(item, name));
            if(! string.IsNullOrEmpty(name))
                if (GrindedIceMenuItems.ContainsKey(name))
                    return (GrindedIce)GrindedIceMenuItems[name].Clone();
            return null;
        }
    }
}
