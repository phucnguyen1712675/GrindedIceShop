using System;

namespace GrindedIceShop.Models.Staffs
{
    public class FullTimeStaff : StaffBase
    {
        public FullTimeStaff(int id, string name, decimal salary)
        {
            StaffId = id;
            Name = name;
            Salary = salary;
        }

        public override string Attendance(DateTime presenceTime) => $"Full time staff: Presence at {presenceTime:dd/MM/yyyy}";
    }
}
