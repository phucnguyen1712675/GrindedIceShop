using GrindedIceShop.Models.Bills;
using GrindedIceShop.Models.Bills.Strategy;
using GrindedIceShop.Models.DataProvider.Bills;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GrindedIceShop.Models.Data.ThreadSafeSingleton
{
    public sealed class BillDataContainer
    {
        private readonly Dictionary<int, Bill> _bills = new Dictionary<int, Bill>();

        private static readonly Lazy<BillDataContainer> instance = new Lazy<BillDataContainer>(() => new BillDataContainer());

        private BillDataContainer()
        {
            var bills = BillDataProvider.GetData();
            bills.ForEach(AddNewBill);
        }

        public Bill GetById(int id) => _bills[id];

        public static BillDataContainer Instance => instance.Value;

        public IEnumerable<Bill> GetAllBills() => _bills.Values;

        public IEnumerable<Bill> GetUnfinishedBills() => _bills.Values.Where(bill => Equals(bill.Status, BillStatus.UnFinished));

        public void AddNewBill(Bill newBill) => _bills[newBill.BillId] = newBill;
    }
}
