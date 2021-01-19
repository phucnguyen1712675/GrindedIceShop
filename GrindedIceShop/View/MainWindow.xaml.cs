using GrindedIceShop.Models.Bases;
using GrindedIceShop.Models.Beverages;
using GrindedIceShop.Models.Beverages.SubBeverages;
using GrindedIceShop.Models.GrindedIces;
using GrindedIceShop.Models.GrindedIces.SubGrindedIces;
using GrindedIceShop.Models.ShopHome;
using GrindedIceShop.Models.Toppings;
using GrindedIceShop.Models.Toppings.SubToppings;
using GrindedIceShop.ViewModel;
using GrindedIceShop.ViewModel.Controls;
using MaterialDesignExtensions.Controls;
using MaterialDesignExtensions.Model;
using System.Collections.Generic;

namespace GrindedIceShop.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MaterialWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
/*
            List<MenuItem> items = new List<MenuItem>();

            MenuItem item1 = GrindedIceMenuItemManager.Instance.GetGrindedIceMenuItem("Chocolate grinded ice");
            (item1 as MainMenuItem).SetSize("S");
            item1 = item1.AddToppingToItem("Cheese").AddToppingToItem("strawberry");
            items.Add(item1);

            MenuItem item2 = GrindedIceMenuItemManager.Instance.GetGrindedIceMenuItem("Taro grinded ice");
            (item2 as MainMenuItem).SetSize("M");
            item2 = item2.AddToppingToItem("Black Bubble").AddToppingToItem("Flan");
            items.Add(item2);

            MenuItem item3 = BeverageMenuItemManager.Instance.GetGrindedIceMenuItem("Milk tea");
            (item3 as MainMenuItem).SetSize("L");
            (item3 as Beverage).SetType("Cold");
            item3 = item3.AddToppingToItem("Black bubble").AddToppingToItem("Egg pudding");
            items.Add(item3);

            MenuItem item4 = null;
            item4 = ToppingManager.Instance.AddBlackBubbleTopping(null);
            items.Add(item4);

            MenuItem item4 = new MainMenuItem();
            item4 = item4.AddToppingToItem("Black bubble");
            items.Add(item4);

            foreach (var item in items)
            {
                string prepare = item.Prepare(); //
                decimal price = item.GetPrice(); //75 //78 //55 //5
            }*/
        }

        private void NavigationItemSelectedHandler(object sender, NavigationItemSelectedEventArgs args)
           => SelectNavigationItem(args.NavigationItem);

        public void SetContentControl(object newContent)
            => contentControl.Content = newContent;

        private void SelectNavigationItem(INavigationItem navigationItem)
        {
            if (navigationItem != null)
            {
                object newContent = navigationItem.NavigationItemSelectedCallback(navigationItem);

                if (contentControl.Content == null || contentControl.Content.GetType() != newContent.GetType())
                {
                    SetContentControl(newContent);
                }
            }
            else
            {
                SetContentControl(null);
            }

            if (appBar != null)
            {
                appBar.IsNavigationDrawerOpen = false;
            }
        }

        //Test
        private void CreateOrderButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var createOrderWindow = new CreateOrderWindow()
            {
                DataContext = CreateOrderViewModel.Instance
            };
            createOrderWindow.Show();
        }
    }
}
