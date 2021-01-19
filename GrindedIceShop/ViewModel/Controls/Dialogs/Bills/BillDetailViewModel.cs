using GrindedIceShop.Models.Bills;
using GrindedIceShop.Models.Customers;
using GrindedIceShop.Models.Payments;
using GrindedIceShop.Models.Staffs;
using GrindedIceShop.Util;
using System.Collections.ObjectModel;

namespace GrindedIceShop.ViewModel.Controls.Dialogs.Bills
{
    public class BillDetailViewModel : ViewModelBase
    {
        public int PaymentSelectedIndex { get; set; }
        public int StaffSelectedIndex { get; set; }
        public int CustomerSelectedIndex { get; set; }
        public Bill Bill { get; set; }
        public ListOfTypes<IPayment> Payments { get; set; }
        public ObservableCollection<StaffBase> Staffs { get; set; }
        public ObservableCollection<Customer> Customers { get; set; }
    }
}
