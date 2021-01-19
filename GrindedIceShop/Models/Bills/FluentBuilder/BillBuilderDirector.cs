namespace GrindedIceShop.Models.Bills.FluentBuilder
{
    public class BillBuilderDirector : BillCustomerBuilder<BillBuilderDirector>
    {
        public static BillBuilderDirector NewBill => new BillBuilderDirector();
    }
}
