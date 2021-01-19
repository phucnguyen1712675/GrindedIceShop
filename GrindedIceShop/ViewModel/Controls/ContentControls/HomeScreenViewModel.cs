using GalaSoft.MvvmLight.Command;
using GrindedIceShop.Models.Bills;
using GrindedIceShop.Models.Bills.FluentBuilder;
using GrindedIceShop.Models.Bills.Strategy;
using GrindedIceShop.Models.Customers;
using GrindedIceShop.Models.Data.ThreadSafeSingleton;
using GrindedIceShop.Models.Payments;
using GrindedIceShop.Models.Payments.Factory;
using GrindedIceShop.Models.Payments.Strategy;
using GrindedIceShop.Models.Staffs;
using GrindedIceShop.Util;
using GrindedIceShop.View.Controls.Dialogs;
using GrindedIceShop.View.Controls.Dialogs.Bills;
using GrindedIceShop.ViewModel.Controls.Dialogs;
using GrindedIceShop.ViewModel.Controls.Dialogs.Bills;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace GrindedIceShop.ViewModel.Controls.ContentControls
{
    public class HomeScreenViewModel : ViewModelBase
    {
        private BillDetailViewModel _billDetailViewModel;
        private readonly int _paymentSelectedIndex;
        private readonly int _staffSelectedIndex;
        private readonly int _customerSelectedIndex;
        private ListOfTypes<IPayment> _payments;
        private ObservableCollection<StaffBase> _staffs;
        private ObservableCollection<Customer> _customers;

        public ObservableCollection<Bill> Bills { get; set; }
        public ICommand AddNewBillCommand { get; }
        public ICommand NotifyCommand { get; }
        public ICommand CheckoutCommand { get; }

        public HomeScreenViewModel()
        {
            this.LoadData();
            this._paymentSelectedIndex = 0;
            this._staffSelectedIndex = 0;
            this._customerSelectedIndex = 0;
            this.AddNewBillCommand = new RelayCommand(ExecuteAddNewBillCommand, () => true);
            this.NotifyCommand = new RelayCommand<int>(ExecuteNotifyCommand, (_) => true);
            this.CheckoutCommand = new RelayCommand<int>(ExecuteCheckoutCommand, (_) => true);
        }

        private void LoadBills()
        {
            /* var temp = BillDataContainer.Instance.GetAllBills();
             this.Bills = temp.ToObservableCollection();*/
            this.Bills = BillDataContainer.Instance.GetUnfinishedBills().ToObservableCollection();
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
            LoadBills();
        }

        #region Dialogs

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

        private async void ExecuteNotifyCommand(int billId)
        {
            /*var messageViewModel = new MessageViewModel
            {
                Message
            };*/

            var view = new BillDetailDialog
            {
                DataContext = this._billDetailViewModel
            };

            //show the dialog
            var result = await DialogHost.Show(view, MainWindowViewModel.Instance.Identifier, ExtendedOpenedEventHandler, ClosingEventHandler).ConfigureAwait(false);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        private async void ExecuteCheckoutCommand(int billId)
        {
            if (!(BillDataContainer.Instance.GetById(billId) is Bill bill)) return;

            bill.Checkout();
            //this.Bills.Remove(bill);
            this.Bills.Remove(Bills[billId]);

            var messageViewModel = new MessageViewModel
            {
                Message = bill.ToString()
            };

            var view = new MessageDialog()
            {
                DataContext = messageViewModel
            };

            //show the dialog
            var result = await DialogHost.Show(view, MainWindowViewModel.Instance.Identifier, ExtendedOpenedEventHandler, ClosingEventHandler).ConfigureAwait(false);

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
            Bills.Add(newBill);
        }

        private static void ClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {


        }

        #endregion
    }
}
