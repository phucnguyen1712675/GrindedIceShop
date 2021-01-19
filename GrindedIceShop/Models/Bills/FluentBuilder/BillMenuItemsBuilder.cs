using GrindedIceShop.Models.Bases;
using GrindedIceShop.Models.Beverages;
using GrindedIceShop.Models.ShopHome;
using GrindedIceShop.Models.Toppings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrindedIceShop.Models.Bills.FluentBuilder
{
    public class BillMenuItemsBuilder<T>: BillStatusBuilder<BillMenuItemsBuilder<T>>  where T : BillMenuItemsBuilder<T> 
    {
        public T WithMenuItems(ObservableCollection<MenuItem> items)
        {
            if (items == null)
                items = new ObservableCollection<MenuItem>(fakeMenuItem());
            Bill.ItemsOrder = items;
            return (T)this;
        }

        public List<MenuItem> fakeMenuItem()
        {
            List<MenuItem> items = new List<MenuItem>();

            MenuItem item1 = GrindedIceMenuItemManager.Instance.GetGrindedIceMenuItem("Chocolate grinded ice");
            (item1 as MainMenuItem).SetSize("S");
            item1 = item1.AddToppingToItem("Cheese").AddToppingToItem("strawberry");
            items.Add(item1);

            MenuItem item2 = GrindedIceMenuItemManager.Instance.GetGrindedIceMenuItem("Taro grinded ice");
            (item2 as MainMenuItem).SetSize("M");
            item2 = item2.AddToppingToItem("Black Bubble").AddToppingToItem("Flan");
            items.Add(item2);

            MenuItem item3 = BeverageMenuItemManager.Instance.GetBeverageMenuItem("Milk tea");
            (item3 as MainMenuItem).SetSize("L");
            (item3 as Beverage).SetType("Cold");
            item3 = item3.AddToppingToItem("Black bubble").AddToppingToItem("Egg pudding");
            items.Add(item3);

            MenuItem item4 = new MainMenuItem();
            item4 = item4.AddToppingToItem("Black bubble");
            items.Add(item4);

            return items;
        }

    }
}
