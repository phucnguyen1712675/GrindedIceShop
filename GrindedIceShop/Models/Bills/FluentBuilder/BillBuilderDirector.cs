namespace GrindedIceShop.Models.Bills.FluentBuilder
{
    public class BillBuilderDirector : BillStatusBuilder<BillBuilderDirector>
    {
        public static BillBuilderDirector NewBill => new BillBuilderDirector();
    }
}
