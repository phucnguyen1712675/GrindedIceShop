using GalaSoft.MvvmLight.Command;
using GrindedIceShop.Models.ShopHome;
using GrindedIceShop.Models.Toppings;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PropertyChanged;
using System;
using GrindedIceShop.Models.Bases;
using GrindedIceShop.Models.Beverages;
using System.Windows;
using GrindedIceShop.Models.GrindedIces;

namespace GrindedIceShop.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    class CreateOrderViewModel : ViewModelBase
    {
        public ObservableCollection<MenuItem> ItemsOrder { get; set; }
//data all element ============
        public ObservableCollection<string> GrindedIceMenuItems { get; set; }
        public ObservableCollection<string> BeverageMenuItems { get; set; }
        public ObservableCollection<string> ToppingItems { get; set; }

//selected element ============
        public string SelectedMainMenuItem {get; set; }
        public string SelectedMainMenuItemSize { get; set; }
        public ObservableCollection<string> SelectedToppingitems { get; set; }
        public string SelectedBeverageType { get; set; }
        public bool IstoppingOnly { get; set; }
        //Selected customer /staff ================== TODO

//Command ============
        private bool _canExecuteCommand;
        //Command Get element ============
        public ICommand AddremoveToppingCommand { get; }
        public ICommand SetBeverageTypeCommand { get; }
        public ICommand SetMainMenuItemCommand { get; }
        public ICommand SetMainMenuItemSizeCommand { get; }

        //Command add - create order ============
        public ICommand AddItemToOrderCommand { get; }
        public ICommand CreateOrderCommand { get; }

        //Command add customer / staff TODO


        private static CreateOrderViewModel instance;
        public static CreateOrderViewModel Instance
        {
            get
            {
                if (instance == null)
                    new CreateOrderViewModel();
                return instance;
            }
        }

        private CreateOrderViewModel()
        {
            CleanAll();

            GrindedIceMenuItems = new ObservableCollection<string>(GrindedIceMenuItemManager.Instance.GetGrindedIceMenuItemsName());
            BeverageMenuItems = new ObservableCollection<string>(BeverageMenuItemManager.Instance.GetBeverageMenuItemsName());
            ToppingItems = new ObservableCollection<string>(ToppingManager.Instance.GetToppingsName());

            _canExecuteCommand = true;
            AddremoveToppingCommand = new RelayCommand<string>(AddRemoveTopping, (_) => this._canExecuteCommand);
            SetBeverageTypeCommand = new RelayCommand<string>(SetBeverageType, (_) => this._canExecuteCommand);
            SetMainMenuItemCommand = new RelayCommand<string>(SetMainMenuItem, (_) => this._canExecuteCommand);
            SetMainMenuItemSizeCommand = new RelayCommand<string>(SetMainMenuItemSize, (_) => this._canExecuteCommand);

            AddItemToOrderCommand = new RelayCommand(AddItemToOrder ,() => this._canExecuteCommand);
            CreateOrderCommand = new RelayCommand(CreateOrder, () => this._canExecuteCommand);

            instance = this;
        }

        public void CleanAll() {
            ItemsOrder = new ObservableCollection<MenuItem>();

            IstoppingOnly = false;
            SelectedMainMenuItem = "";
            SelectedBeverageType = "";
            SelectedToppingitems = new ObservableCollection<string>();
        }

        private void CreateOrder()
        {
            string result = "";
            int i = 1;
            decimal total = 0;
           foreach( MenuItem item in ItemsOrder)
            {
                result += $"item_{i} : {item.GetPrice()} vnd\n";
                string resultItem = $"Prepare: {item.Prepare()}\n";
                result += resultItem;
                total += item.GetPrice();
                i++;
            }

            result += $"\n\t total: {total} vnd";
            MessageBox.Show(result);
            CleanAll();
        }

        private void AddItemToOrder()
        {
            MenuItem newItem = new MainMenuItem();
            if (!IstoppingOnly)
            {
                newItem = GrindedIceMenuItemManager.Instance.GetGrindedIceMenuItem(SelectedMainMenuItem);
                if (newItem == null)
                {
                    newItem = BeverageMenuItemManager.Instance.GetBeverageMenuItem(SelectedMainMenuItem);
                    (newItem as Beverage).SetType(SelectedBeverageType);
                }
              (newItem as MainMenuItem).SetSize(SelectedMainMenuItemSize);
            }
            

            foreach (string topping in SelectedToppingitems)
                newItem = newItem.AddToppingToItem(topping);

            ItemsOrder.Add(newItem);
            MessageBox.Show("Success");
        }

        private void SetMainMenuItem(string MainMenuItemStr)
        {
            SelectedMainMenuItem = MainMenuItemStr;
        }

        private void SetBeverageType(string BeverageTypeStr)
        {
            SelectedBeverageType = BeverageTypeStr;
        }

        private void AddRemoveTopping(string Toppingstr)
        {
            if (SelectedToppingitems.Contains(Toppingstr))
                SelectedToppingitems.Remove(Toppingstr);
            else
                SelectedToppingitems.Add(Toppingstr);
        }

        private void SetMainMenuItemSize(string SizeStr)
        {
            SelectedMainMenuItemSize = SizeStr;
        }
    }
}
