using GrindedIceShop.Models.Bases;
using GrindedIceShop.Models.Bills.Strategy;
using GrindedIceShop.Models.Customers;
using GrindedIceShop.Models.Payments;
using GrindedIceShop.Models.Staffs;
using PropertyChanged;
using System;
using System.Collections.ObjectModel;
using System.Windows;


namespace GrindedIceShop.Models.Bills
{
    [AddINotifyPropertyChangedInterface]
    public class Bill
    {
        public int BillId { get; set; }
        public DateTime Date { get; set; }
        public decimal ReceivedAmount { get; set; }
        public IPayment Payment { get; set; }
        public BillStatus Status { get; set; }

        public ObservableCollection<MenuItem> ItemsOrder { get; set; }

        public virtual StaffBase Cashier { get; set; }
        public virtual Customer Customer { get; set; }


        public void SetBillId(int id)
        {
            BillId = id;
        }

        public void Notify()
        {
            MessageBox.Show($"Customer: {Customer.Name}'s order_{BillId} is done !");
        }

        public void AddItem(MenuItem item)
        {
            ItemsOrder.Add(item);
        }

        public override string ToString()
        {
            return $"Date: {Date}{Environment.NewLine}Received Amount: {ReceivedAmount}{Environment.NewLine}Payment:{Environment.NewLine}{Payment.ExecutePaymentLogic(ReceivedAmount)}{Environment.NewLine}Status: {Status}{Environment.NewLine}Cashier: {Cashier.Name}{Environment.NewLine}Customer: {Customer.Name}";
        }

        public void Checkout()
        {
            if (Equals(this.Status, BillStatus.UnFinished))
            {
                this.Status = BillStatus.Finished;
            }
            string result ="CheckOut :\n"  +  ToString();
            MessageBox.Show(result);
        }

        public void PrepareOrders()
        {
            string result = "";
            int i = 1;
            foreach (MenuItem item in ItemsOrder)
            {
                result += $"item_{i} : {item.GetPrice()} vnd\n";
                string resultItem = $"Prepare: {item.Prepare()}\n";
                result += resultItem;
                i++;
            }
            MessageBox.Show(result);
        }

        public decimal GetTotalPrice()
        {
            decimal total = 0;
            foreach (var item in ItemsOrder)
                total += item.GetPrice();
            return total;
        }
    }
}
