using GrindedIceShop.Models.Customers;
using GrindedIceShop.Models.Staffs;
using PropertyChanged;
using System;

namespace GrindedIceShop.Models.Bills
{
    [AddINotifyPropertyChangedInterface]
    public class Bill
    {
        public int BillId { get; set; }
        public DateTime Date { get; set; }
        public decimal ReceivedAmount { get; set; }

        public virtual StaffBase Cashier { get; set; }
        public virtual Customer Customer { get; set; }

        public override string ToString()
        {
            return $"Date: {Date}, Received Amount: {ReceivedAmount}, Cashier: {Cashier.Name}, Customer: {Customer.Name}";
        }
    }
}
