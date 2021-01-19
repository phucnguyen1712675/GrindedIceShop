using GrindedIceShop.Models.Data.ThreadSafeSingleton;

namespace GrindedIceShop.Models.Bills.FluentBuilder
{
    public class BillCustomerBuilder<T> : BillCashierBuilder<BillCustomerBuilder<T>> where T : BillCustomerBuilder<T>
    {
        public T OfCustomer(int CustomerId)
        {
            Bill.Customer = CustomerDataContainer.Instance.GetById(CustomerId);
            return (T)this;
        }

        public T OfCustomer(string phoneNumber)
        {
            Bill.Customer = CustomerDataContainer.Instance.GetByPhoneNumber(phoneNumber);
            return (T)this;
        }

    }
}
