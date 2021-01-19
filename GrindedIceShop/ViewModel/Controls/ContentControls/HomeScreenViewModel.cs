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
using GrindedIceShop.ViewModel.Controls.Dialogs.Bills;
using MaterialDesignThemes.Wpf;
using NSwag.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace GrindedIceShop.ViewModel.Controls.ContentControls
{
    public class HomeScreenViewModel : ViewModelBase
    {
        private static HomeScreenViewModel instance;
        public static HomeScreenViewModel Instance
        {
            get
            {
                if (instance == null)
                    new HomeScreenViewModel();
                return instance;
            }
        }

        private BillDetailViewModel _billDetailViewModel;
        private readonly int _paymentSelectedIndex;
        private readonly int _staffSelectedIndex;
        private readonly int _customerSelectedIndex;
        private ListOfTypes<IPayment> _payments;
        private ObservableCollection<StaffBase> _staffs;
        private ObservableCollection<Customer> _customers;

        public Dictionary<int,Bill> Bills { get; set; }
        public int HandleBillId { get; set; }

        public ICommand AddNewBillCommand { get; }
        public ICommand NotifyCommand { get; }
        public ICommand CheckoutCommand { get; }
        public ICommand PrepareCommand { get; }

        public HomeScreenViewModel()
        {
            HandleBillId = 1;
            Bills = new Dictionary<int, Bill>();
            this.LoadData();
            this._paymentSelectedIndex = 0;
            this._staffSelectedIndex = 0;
            this._customerSelectedIndex = 0;
            this.NotifyCommand = new RelayCommand<int>(ExecuteNotifyCommand, (_) => true);
            this.CheckoutCommand = new RelayCommand<int>(ExecuteCheckoutCommand, (_) => true);
            this.PrepareCommand = new RelayCommand<int>(ExecutePrepareBillCommand, (_) => true);
            instance = this;
        }



        public void AddBill(Bill bill)
        {
            bill.SetBillId(HandleBillId);
            Bills.Add(HandleBillId, bill);
            HandleBillId++;
        }

        private void LoadBills() //Fake data
        {
            var dataBills = BillDataContainer.Instance.GetUnfinishedBills().ToList();
            foreach(var bill in dataBills)
            {
                AddBill(bill);
            }
        }

        private void reloadBills()
        {
            Dictionary<int,Bill> tempBills = new Dictionary<int, Bill>();
            foreach(var item in Bills)
            {
                tempBills.Add(item.Key, item.Value);
            }
            Bills.Clear();
            Bills = tempBills;
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

        private async void ExecuteNotifyCommand(int billId)
        {
            if (Bills.ContainsKey(billId))
                Bills[billId].Notify();
        }

        private async void ExecuteCheckoutCommand(int billId)
        {
            if (Bills.ContainsKey(billId))
            {
                Bills[billId].Checkout();
                Bills.Remove(billId);
                reloadBills();
            }
        }

        private void ExecutePrepareBillCommand(int billId)
        {
            if (Bills.ContainsKey(billId))
                Bills[billId].PrepareOrders();
        }

        #endregion
    }
}
