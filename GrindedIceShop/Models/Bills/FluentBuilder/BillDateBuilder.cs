using System;

namespace GrindedIceShop.Models.Bills.FluentBuilder
{
    public class BillDateBuilder<T> : BillBuilder where T : BillDateBuilder<T>
    {
        public T AtDate(DateTime date)
        {
            Bill.Date = date;
            return (T)this;
        }
    }
}
