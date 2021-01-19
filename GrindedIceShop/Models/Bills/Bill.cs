using GrindedIceShop.Models.Bases;
using GrindedIceShop.Models.Customers;
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

        public ObservableCollection<MenuItem> ItemsOrder { get; set; }

        public virtual StaffBase Cashier { get; set; }
        public virtual Customer Customer { get; set; }

        //public override string ToString()
        //{
        //    return $"Date: {Date}, Received Amount: {ReceivedAmount}, Cashier: {Cashier.Name}, Customer: {Customer.Name}";
        //}
        public void SetBillId(int id)
        {
            BillId = id;
        }

        public void Notify(int id)
        {
            MessageBox.Show($"Customer: {Customer.Name}'s order_{id} is done !");
        }

        public void AddItem(MenuItem item)
        {
            ItemsOrder.Add(item);
        }

        public void PrepareOrders()
        {
            string result = "";
            foreach (var item in ItemsOrder)
                result += item.Prepare() + "\n";
            MessageBox.Show(result);
        }

        public decimal GetTotalPrice()
        {
            decimal total = 0;
            foreach (var item in ItemsOrder)
                total += item.GetPrice();
            return total;
        }

        /*public void CheckOutBill(string stringPaymentMethod) { 
         *  //TODO
         * }*/
    }
}
