namespace GrindedIceShop.Models.Bills.FluentBuilder
{
    public abstract class BillBuilder
    {
        private static int _nextId;

        protected readonly Bill Bill;

        static BillBuilder()
        {
            _nextId = 0;
        }

        protected BillBuilder()
        {
            Bill = new Bill()
            {
                BillId = _nextId++
            };
        }

        public Bill Build() => Bill;
    }
}
