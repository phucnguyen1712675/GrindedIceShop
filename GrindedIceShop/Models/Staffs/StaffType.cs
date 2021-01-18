using GrindedIceShop.Utils;

namespace GrindedIceShop.Models.Staffs
{
    public abstract class StaffType : Enumeration
    {
        public static readonly StaffType PartTime
            = new PartTimeType();

        public static readonly StaffType FullTime
           = new FullTimeType();

        protected StaffType(int id, string name) : base(id, name) { }

        public abstract decimal BonusSize { get; }

        private class PartTimeType : StaffType
        {
            public PartTimeType() : base(0, nameof(PartTimeType)) { }

            public override decimal BonusSize => 100000m;
        }

        private class FullTimeType : StaffType
        {
            public FullTimeType() : base(1, nameof(FullTimeType)) { }

            public override decimal BonusSize => 300000m;
        }
    }
}
