using GrindedIceShop.Models.Bills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrindedIceShop.Models.ShopHome
{
    class Shop
    {
        private static Shop instance;
        public static Shop Instace
        {
            get
            {
                if (instance == null)
                    new Shop();
                return instance;
            }
        }

        public Dictionary<int, Bill> Bills { get; set; }
        public int handleBillId = 1;

        private Shop()
        {
            instance = this;
        }

        public void AddBillToShop(Bill bill)
        {
            bill.SetBillId(handleBillId);
            Bills.Add(handleBillId, bill);
            handleBillId++;
        }

        public void Notify(int id)
        {
            if (Bills.ContainsKey(id))
            {
                Bills[id].Notify();
                RemoveBill(id);
            }
        }

        public void RemoveBill(int id)
        {
            if (Bills.ContainsKey(id))
                Bills.Remove(id);
        }

        public void PrepareBill(int id)
        {
            if (Bills.ContainsKey(id))
                Bills[id].PrepareOrders();
        }

       /* public void CheckOutBill(int id, string stringPaymentMethod) {
        * //TODO
        * }*/
    }
}
