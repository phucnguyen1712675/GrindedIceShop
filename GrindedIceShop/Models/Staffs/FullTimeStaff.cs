using System;

namespace GrindedIceShop.Models.Staffs
{
    public class FullTimeStaff : StaffBase
    {
        //private readonly DateTime _presenceTime;

        /*public FullTimeStaff(DateTime presenceTime)
        {
            _presenceTime = presenceTime;
        }*/

        public FullTimeStaff(int id, string name, decimal salary)
        {
            StaffId = id;
            Name = name;
            Salary = salary;
        }

        public override string Attendance(DateTime presenceTime) => $"Full time staff: Presence at {presenceTime:dd/MM/yyyy}";
    }
}
