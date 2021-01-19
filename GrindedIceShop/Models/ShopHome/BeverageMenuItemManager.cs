using GrindedIceShop.Models.Bases;
using GrindedIceShop.Models.Beverages;
using GrindedIceShop.Models.Beverages.SubBeverages;
using GrindedIceShop.Models.SupportCompareStrings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrindedIceShop.Models.ShopHome
{
    class BeverageMenuItemManager
    {

        private static BeverageMenuItemManager instance;
        public static BeverageMenuItemManager Instance
        {
            get
            {
                if (instance == null)
                    new BeverageMenuItemManager();
                return instance;
            }
        }

        public Dictionary<string, Beverage> BeverageMenuItems { get; set; }
        private BeverageMenuItemManager()
        {
            BeverageMenuItems = new Dictionary<string, Beverage>();
            BeverageMenuItems.Add("Tea", new Tea());
            BeverageMenuItems.Add("Milk tea", new MilkTea());
            instance = this;
        }

        public List<string> GetBeverageMenuItemsName()
        {
            return BeverageMenuItems.Keys.ToList();
        }

        public Beverage GetBeverageMenuItem(string name)
        {
            name = BeverageMenuItems.Keys.ToList().FirstOrDefault(item => new MyCompareString().CompareString(item, name));
            if(name != null)
                if (BeverageMenuItems.ContainsKey(name))
                    return (Beverage)BeverageMenuItems[name].Clone();
            return null;
        }
    }
}
