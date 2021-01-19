namespace GrindedIceShop.Models.Bills.FluentBuilder
{
    public abstract class BillBuilder
    {
        protected readonly Bill Bill;

        protected BillBuilder() => Bill = new Bill();

        public Bill Build() => Bill;
    }
}
