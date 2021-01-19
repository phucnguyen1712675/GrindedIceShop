using PropertyChanged;
using System;

namespace GrindedIceShop.Models.Staffs
{
    [AddINotifyPropertyChangedInterface]
    public abstract class StaffBase
    {
        public int StaffId { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }

        public override string ToString() => $"Name: {Name}, Salary: {Salary}";

        public abstract string Attendance(DateTime presenceTime);
    }
}
