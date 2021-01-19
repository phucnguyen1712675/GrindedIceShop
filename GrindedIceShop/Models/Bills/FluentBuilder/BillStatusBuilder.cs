using GrindedIceShop.Models.Bills.Strategy;

namespace GrindedIceShop.Models.Bills.FluentBuilder
{
    public class BillStatusBuilder<T> : BillPaymentBuilder<BillStatusBuilder<T>> where T : BillStatusBuilder<T>
    {
        public T WithStatus(BillStatus billStatus)
        {
            Bill.Status = billStatus;
            return (T)this;
        }
    }
}
