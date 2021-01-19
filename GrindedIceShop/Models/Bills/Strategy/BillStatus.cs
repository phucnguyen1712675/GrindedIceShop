using GrindedIceShop.Utils;

namespace GrindedIceShop.Models.Bills.Strategy
{
    public abstract class BillStatus : Enumeration
    {
        public static readonly BillStatus Finished
            = new FinishedStatus();

        public static readonly BillStatus UnFinished
            = new UnFinishedStatus();

        private BillStatus(int id, string name) : base(id, name) { }

        public abstract override string ToString();

        private class FinishedStatus : BillStatus
        {
            public FinishedStatus() : base(0, nameof(FinishedStatus)) { }

            public override string ToString()
                => "Finished";
        }

        private class UnFinishedStatus : BillStatus
        {
            public UnFinishedStatus() : base(0, nameof(UnFinishedStatus)) { }

            public override string ToString()
                => "Unfinished";
        }
    }
}
