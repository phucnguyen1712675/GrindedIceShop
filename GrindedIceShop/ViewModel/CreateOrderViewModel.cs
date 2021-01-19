using GalaSoft.MvvmLight.Command;
using GrindedIceShop.Models.Bases;
using GrindedIceShop.Models.Beverages;
using GrindedIceShop.Models.Bills;
using GrindedIceShop.Models.Bills.FluentBuilder;
using GrindedIceShop.Models.Bills.Strategy;
using GrindedIceShop.Models.Customers;
using GrindedIceShop.Models.Data.ThreadSafeSingleton;
using GrindedIceShop.Models.Payments;
using GrindedIceShop.Models.Payments.Factory;
using GrindedIceShop.Models.Payments.Strategy;
using GrindedIceShop.Models.ShopHome;
using GrindedIceShop.Models.Staffs;
using GrindedIceShop.Models.Toppings;
using GrindedIceShop.Util;
using GrindedIceShop.View.Controls.Dialogs.Bills;
using GrindedIceShop.ViewModel.Controls;
using GrindedIceShop.ViewModel.Controls.Dialogs.Bills;
using MaterialDesignThemes.Wpf;
using PropertyChanged;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace GrindedIceShop.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    class CreateOrderViewModel : ViewModelBase
    {
        private BillDetailViewModel _billDetailViewModel;
        private readonly int _paymentSelectedIndex;
        private readonly int _staffSelectedIndex;
        private readonly int _customerSelectedIndex;
        private ListOfTypes<IPayment> _payments;
        private ObservableCollection<StaffBase> _staffs;
        private ObservableCollection<Customer> _customers;

        public ObservableCollection<MenuItem> ItemsOrder { get; set; }
        //data all element ============
        public ObservableCollection<string> GrindedIceMenuItems { get; set; }
        public ObservableCollection<string> BeverageMenuItems { get; set; }
        public ObservableCollection<string> ToppingItems { get; set; }

        //selected element ============
        public string SelectedMainMenuItem { get; set; }
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
        public ICommand AddNewBillCommand { get; }

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
            LoadData();
            this._paymentSelectedIndex = 0;
            this._staffSelectedIndex = 0;
            this._customerSelectedIndex = 0;
            GrindedIceMenuItems = new ObservableCollection<string>(GrindedIceMenuItemManager.Instance.GetGrindedIceMenuItemsName());
            BeverageMenuItems = new ObservableCollection<string>(BeverageMenuItemManager.Instance.GetBeverageMenuItemsName());
            ToppingItems = new ObservableCollection<string>(ToppingManager.Instance.GetToppingsName());

            _canExecuteCommand = true;
            AddremoveToppingCommand = new RelayCommand<string>(AddRemoveTopping, (_) => this._canExecuteCommand);
            SetBeverageTypeCommand = new RelayCommand<string>(SetBeverageType, (_) => this._canExecuteCommand);
            SetMainMenuItemCommand = new RelayCommand<string>(SetMainMenuItem, (_) => this._canExecuteCommand);
            SetMainMenuItemSizeCommand = new RelayCommand<string>(SetMainMenuItemSize, (_) => this._canExecuteCommand);

            AddItemToOrderCommand = new RelayCommand(AddItemToOrder, () => this._canExecuteCommand);
            CreateOrderCommand = new RelayCommand(CreateOrder, () => this._canExecuteCommand);
            this.AddNewBillCommand = new RelayCommand(ExecuteAddNewBillCommand, () => true);

            instance = this;
        }

        private void LoadPayments()
        {
            _payments = new ListOfTypes<IPayment>();
            _payments.Add<Cash>();
            _payments.Add<Momo>();
            _payments.Add<ZaloPay>();

            //this._paymentSelectedIndex = Payments.IndexOf((Type)Convert.ChangeType(Bill.Payment, typeof(IPayment)));
        }

        private void LoadStaffs()
        {
            _staffs = StaffDataContainer.Instance.GetAllStaffs().ToObservableCollection();

            //this._staffSelectedIndex = Staffs.IndexOf(Bill.Cashier);
        }

        private void LoadCustomers()
        {
            _customers = CustomerDataContainer.Instance.GetAllCustomers().ToObservableCollection();

            //this._customerSelectedIndex = Customers.IndexOf(Bill.Customer);
        }

        private void LoadData()
        {
            LoadPayments();
            LoadStaffs();
            LoadCustomers();
            //LoadBills();
        }

        public void CleanAll()
        {
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

            var selectedStaff = this._staffs[this._staffSelectedIndex];
            var selectedCustomer = this._customers[this._customerSelectedIndex];
            var selectedPaymentType = this._payments[this._paymentSelectedIndex];
            var selectedPayment = PaymentFactory.InitializeFactory()[selectedPaymentType.Name];

            var newBill =
                BillBuilderDirector
                    .NewBill
                    .AtDate(DateTime.Now)
                    .Receive(78000m)
                    .ByCashier(selectedStaff.StaffId)
                    .OfCustomer(selectedCustomer.CustomerId)
                    .PaidByPayment(selectedPayment)
                    .WithStatus(BillStatus.UnFinished)
                    .Build();

            foreach (MenuItem item in ItemsOrder)
            {
                result += $"item_{i} : {item.GetPrice()} vnd\n";
                string resultItem = $"Prepare: {item.Prepare()}\n";
                result += resultItem;
                total += item.GetPrice();
                i++;
            }
            //TODO
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

        private async void ExecuteAddNewBillCommand()
        {
            var maxBillId = BillDataContainer.Instance.GetAllBills().ToObservableCollection().Max(bill => bill.BillId);

            this._billDetailViewModel = new BillDetailViewModel
            {
                PaymentSelectedIndex = this._paymentSelectedIndex,
                StaffSelectedIndex = this._staffSelectedIndex,
                CustomerSelectedIndex = this._customerSelectedIndex,
                Bill = new Bill
                {
                    BillId = maxBillId + 1
                },
                Payments = this._payments,
                Staffs = this._staffs,
                Customers = this._customers
            };

            var view = new BillDetailDialog
            {
                DataContext = this._billDetailViewModel
            };

            //show the dialog
            var result = await DialogHost.Show(view, MainWindowViewModel.Instance.Identifier, ExtendedOpenedEventHandler, AddNewBillClosingEventHandler).ConfigureAwait(false);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        private void AddNewBillClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter is bool parameter && !parameter) return;

            var selectedStaff = this._staffs[this._staffSelectedIndex];
            var selectedCustomer = this._customers[this._customerSelectedIndex];
            var selectedPaymentType = this._payments[this._paymentSelectedIndex];
            var selectedPayment = PaymentFactory.InitializeFactory()[selectedPaymentType.Name];

            var newBill =
                BillBuilderDirector
                    .NewBill
                    .AtDate(DateTime.Now)
                    .Receive(this._billDetailViewModel.Bill.ReceivedAmount)
                    .ByCashier(selectedStaff.StaffId)
                    .OfCustomer(selectedCustomer.CustomerId)
                    .PaidByPayment(selectedPayment)
                    .WithStatus(BillStatus.UnFinished)
                    .Build();

            BillDataContainer.Instance.AddNewBill(newBill);
            //Bills.Add(newBill);
        }
    }
}
