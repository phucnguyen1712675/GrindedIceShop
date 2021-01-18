using GrindedIceShop.Models.Staffs.FactoryMethodRefactoringTechnique;
using System;
using System.Collections.Generic;

namespace GrindedIceShop.Models.Staffs
{
    public sealed class Staff
    {
        private static int _nextId;
        private readonly Dictionary<StaffType, IStaffFactory> _factories;

        static Staff()
        {
            _nextId = 0;
        }

        private Staff()
        {
            _factories = new Dictionary<StaffType, IStaffFactory>();

            foreach (StaffType type in Enum.GetValues(typeof(StaffType)))
            {
                var factory = (IStaffFactory)Activator.CreateInstance(Type.GetType("FactoryMethod" + Enum.GetName(typeof(StaffType), type) + "Factory"));
                _factories.Add(type, factory);
            }
        }

        public static Staff InitializeFactories() => new Staff();

        public StaffBase ExecuteCreateStaff(StaffType staffType, string name, decimal salary) => _factories[staffType].Create(_nextId++, name, salary);
    }
}
