namespace GrindedIceShop.Models.Bills.FluentBuilder
{
    public class BillReceivedAmountBuilder<T> : BillDateBuilder<BillReceivedAmountBuilder<T>> where T : BillReceivedAmountBuilder<T>
    {
        public T Receive(decimal amount)
        {
            bill.ReceivedAmount = amount;
            return (T)this;
        }
    }
}
