using GrindedIceShop.Models.Data.ThreadSafeSingleton;

namespace GrindedIceShop.Models.Bills.FluentBuilder
{
    public class BillCashierBuilder<T> : BillReceivedAmountBuilder<BillCashierBuilder<T>> where T : BillCashierBuilder<T>
    {
        public T ByCashier(int staffId)
        {
            Bill.Cashier = StaffDataContainer.Instance.GetById(staffId);
            return (T)this;
        }
    }
}
