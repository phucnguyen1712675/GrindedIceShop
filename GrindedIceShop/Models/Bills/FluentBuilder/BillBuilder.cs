namespace GrindedIceShop.Models.Bills.FluentBuilder
{
    public abstract class BillBuilder
    {
        private static int nextId;

        protected Bill bill;

        static BillBuilder()
        {
            nextId = 0;
        }

        protected BillBuilder()
        {
            bill = new Bill()
            {
                BillId = nextId++
            };
        }

        public Bill Build() => bill;
    }
}
