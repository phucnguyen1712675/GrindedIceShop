using GrindedIceShop.Models.Staffs;
using System.Collections.Generic;
using GrindedIceShop.Models.Staffs.FactoryMethodRefactoringTechnique;

namespace GrindedIceShop.Models.DataProvider.Staffs
{
    public static class StaffDataProvider
    {
        public static List<StaffBase> GetData() =>
            new List<StaffBase>
            {
                StaffFactory
                .InitializeFactories()
                .ExecuteCreateStaff(StaffTypes.PartTime, "Ngô Nha Trang", 3000000m),
                StaffFactory
                .InitializeFactories()
                .ExecuteCreateStaff(StaffTypes.PartTime, "Võ Thiện Tín", 2500000m),
                StaffFactory
                .InitializeFactories()
                .ExecuteCreateStaff(StaffTypes.FullTime, "Nguyễn Thành Vĩnh Phúc", 7000000m)
            };
    }
}
