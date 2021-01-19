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

        public StaffBase ShallowCopy() => (StaffBase)this.MemberwiseClone();

        public StaffBase DeepCopy()
        {
            var clone = (StaffBase)this.MemberwiseClone();
            clone.Name = string.Copy(Name);
            return clone;
        }
    }
}
