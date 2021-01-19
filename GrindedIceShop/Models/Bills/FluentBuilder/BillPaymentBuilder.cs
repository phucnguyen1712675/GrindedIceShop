using GrindedIceShop.Models.Payments;

namespace GrindedIceShop.Models.Bills.FluentBuilder
{
    public class BillPaymentBuilder<T> : BillCustomerBuilder<BillPaymentBuilder<T>> where T : BillPaymentBuilder<T>
    {
        public T PaidByPayment(IPayment payment)
        {
            Bill.Payment = payment;
            return (T)this;
        }
    }
}
