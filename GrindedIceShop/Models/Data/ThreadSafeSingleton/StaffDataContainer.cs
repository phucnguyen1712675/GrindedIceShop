using GrindedIceShop.Models.DataProvider.Staffs;
using GrindedIceShop.Models.Staffs;
using System;
using System.Collections.Generic;

namespace GrindedIceShop.Models.Data.ThreadSafeSingleton
{
    public sealed class StaffDataContainer : ISingletonContainer
    {
        private readonly Dictionary<int, StaffBase> _staffs = new Dictionary<int, StaffBase>();

        private static readonly Lazy<StaffDataContainer> instance = new Lazy<StaffDataContainer>(() => new StaffDataContainer());

        private StaffDataContainer()
        {
            var staffs = StaffDataProvider.GetData();
            staffs.ForEach(staff => _staffs.Add(staff.StaffId, staff));
        }

        public dynamic GetById(int id) => _staffs[id];

        public static StaffDataContainer Instance => instance.Value;
    }
}
