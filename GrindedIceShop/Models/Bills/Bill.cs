using GrindedIceShop.Models.Bills.Strategy;
using GrindedIceShop.Models.Customers;
using GrindedIceShop.Models.Payments;
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
        public IPayment Payment { get; set; }
        public BillStatus Status { get; set; }

        public virtual StaffBase Cashier { get; set; }
        public virtual Customer Customer { get; set; }

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
        }
    }
}
