using GrindedIceShop.Utils;

namespace GrindedIceShop.Models.Commands
{
    public class PriceAction : Enumeration
    {
        public static readonly PriceAction Increase = new PriceAction(0, nameof(Increase));
        public static readonly PriceAction Decrease = new PriceAction(1, nameof(Increase));

        protected PriceAction(int id, string name) : base(id, name) { }
    }
}
