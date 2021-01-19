namespace GrindedIceShop.Models.Bills.FluentBuilder
{
    public class BillReceivedAmountBuilder<T> : BillDateBuilder<BillReceivedAmountBuilder<T>> where T : BillReceivedAmountBuilder<T>
    {
        public T Receive(decimal amount)
        {
            Bill.ReceivedAmount = amount;
            return (T)this;
        }
    }
}
