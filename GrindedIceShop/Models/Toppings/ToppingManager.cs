using GrindedIceShop.Models.Bases;
using GrindedIceShop.Models.SupportCompareStrings;
using GrindedIceShop.Models.Toppings.SubToppings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrindedIceShop.Models.Toppings
{
    public class ToppingManager
    {
        private static ToppingManager instance;
        public static ToppingManager Instance
        {
            get
            {
                if (instance == null)
                    new ToppingManager();
                return instance;
            }
        }

        public Dictionary<string, Delegate> Toppings { get; set; }

        private ToppingManager()
        {
            Toppings = new Dictionary<string, Delegate>();
            Toppings.Add("Flan", new Func<MenuItem, MenuItem>(AddFlanTopping));
            Toppings.Add("Strawberry", new Func<MenuItem, MenuItem>(AddStrawberryTopping));
            Toppings.Add("Cheese", new Func<MenuItem, MenuItem>(AddCheeseTopping));
            Toppings.Add("Golden pearl bubble", new Func<MenuItem, MenuItem>(AddGoldenPearlBubbleTopping));
            Toppings.Add("Black bubble", new Func<MenuItem, MenuItem>(AddBlackBubbleTopping));
            Toppings.Add("White bubble", new Func<MenuItem, MenuItem>(AddWhitebubbleTopping));
            Toppings.Add("Egg pudding", new Func<MenuItem, MenuItem>(AddEggpuddingTopping));
            Toppings.Add("Match pudding", new Func<MenuItem, MenuItem>(AddMatchpuddingTopping));
            instance = this;
        }

       public MenuItem AddToppingToItem(MenuItem Menuitem, string Topping)
        {
            Topping = Toppings.Keys.ToList().FirstOrDefault(item => new MyCompareString().CompareString(item, Topping));
            if (Toppings.ContainsKey(Topping))
                return (MenuItem)Toppings[Topping].DynamicInvoke(Menuitem);
            return Menuitem;
        }

        public List<string> GetToppingsName()
        {
            return Toppings.Keys.ToList();
        }

        public MenuItem AddBlackBubbleTopping(MenuItem arg)
        {
            return new BlackBubble(arg);
        }

        public MenuItem AddGoldenPearlBubbleTopping(MenuItem arg)
        {
            return new GoldenPearlBubble(arg);
        }

        public MenuItem AddCheeseTopping(MenuItem arg)
        {
            return new Cheese(arg);
        }

        public MenuItem AddStrawberryTopping(MenuItem arg)
        {
            return new Strawberry(arg);
        }

        public MenuItem AddFlanTopping(MenuItem arg)
        {
            return new Flan(arg);
        }
        public MenuItem AddMatchpuddingTopping(MenuItem arg)
        {
            return new MatchaPudding(arg);
        }

        public MenuItem AddEggpuddingTopping(MenuItem arg)
        {
            return new EggPudding(arg);
        }

        public MenuItem AddWhitebubbleTopping(MenuItem arg)
        {
            return new WhiteBubble(arg);
        }
    }
}
