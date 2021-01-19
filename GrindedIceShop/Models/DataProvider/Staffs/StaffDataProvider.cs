using GrindedIceShop.Models.Staffs;
using System.Collections.Generic;

namespace GrindedIceShop.Models.DataProvider.Staffs
{
    public static class StaffDataProvider
    {
        public static List<StaffBase> GetData() =>
            new List<StaffBase>
            {
                Staff
                .InitializeFactories()
                .ExecuteCreateStaff(StaffType.PartTime, "Ngô Nha Trang", 3000000m),
                Staff
                .InitializeFactories()
                .ExecuteCreateStaff(StaffType.PartTime, "Võ Thiện Tín", 2500000m),
                Staff
                .InitializeFactories()
                .ExecuteCreateStaff(StaffType.FullTime, "Nguyễn Thành Vĩnh Phúc", 7000000m),
            };
    }
}
