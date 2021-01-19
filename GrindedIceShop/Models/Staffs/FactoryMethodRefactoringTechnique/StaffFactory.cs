using System;
using System.Collections.Generic;

namespace GrindedIceShop.Models.Staffs.FactoryMethodRefactoringTechnique
{
    public sealed class StaffFactory
    {
        private static int _nextId;
        private readonly Dictionary<StaffTypes, IStaffFactory> _factories;

        static StaffFactory() => _nextId = 0;

        private StaffFactory()
        {
            _factories = new Dictionary<StaffTypes, IStaffFactory>();

            foreach (StaffTypes type in Enum.GetValues(typeof(StaffTypes)))
            {
                var typeName = Enum.GetName(typeof(StaffTypes), type);
                var factoryType = Type.GetType("GrindedIceShop.Models.Staffs.FactoryMethodRefactoringTechnique." + typeName + "StaffFactory");
                var factory = (IStaffFactory)Activator.CreateInstance(factoryType ?? DefaultFactoryType());
                _factories.Add(type, factory);
            }
        }

        private static Type DefaultFactoryType() => Type.GetType("GrindedIceShop.Models.Staffs.FactoryMethodRefactoringTechnique.PartTimeStaffFactory");

        public static StaffFactory InitializeFactories() => new StaffFactory();

        public StaffBase ExecuteCreateStaff(StaffTypes staffType, string name, decimal salary) => _factories[staffType].Create(_nextId++, name, salary);
    }
}
