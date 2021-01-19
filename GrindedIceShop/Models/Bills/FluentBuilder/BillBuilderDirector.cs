namespace GrindedIceShop.Models.Bills.FluentBuilder
{
    public class BillBuilderDirector : BillMenuItemsBuilder<BillBuilderDirector>
    {
        public static BillBuilderDirector NewBill => new BillBuilderDirector();
    }
}
