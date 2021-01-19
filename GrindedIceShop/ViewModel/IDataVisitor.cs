using GrindedIceShop.Models.Data.ThreadSafeSingleton;

namespace GrindedIceShop.ViewModel
{
    public interface IDataVisitor
    {
        void VisitBillDataContainer(BillDataContainer billDataContainer);
        void VisitStaffDataContainer(StaffDataContainer staffDataContainer);
        void VisitCustomerDataContainer(CustomerDataContainer customerDataContainer);
    }
}
