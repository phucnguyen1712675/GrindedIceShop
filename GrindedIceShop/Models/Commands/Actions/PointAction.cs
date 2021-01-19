using GrindedIceShop.Utils;

namespace GrindedIceShop.Models.Commands.Actions
{
    public class PointAction : Enumeration
    {
        public static readonly PointAction Increase = new PointAction(0, nameof(Increase));
        public static readonly PointAction Decrease = new PointAction(1, nameof(Increase));

        protected PointAction(int id, string name) : base(id, name) { }
    }
}
