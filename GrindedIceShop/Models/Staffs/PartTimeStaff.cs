using System;

namespace GrindedIceShop.Models.Staffs
{
    public class PartTimeStaff : StaffBase
    {
        public PartTimeStaff(int id, string name, decimal salary)
        {
            StaffId = id;
            Name = name;
            Salary = salary;
        }

        public override string Attendance(DateTime presenceTime) => $"Part time staff: Presence at {presenceTime:dd/MM/yyyy}";
    }
}
