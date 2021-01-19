namespace GrindedIceShop.Models.Staffs.FactoryMethodRefactoringTechnique
{
    public class FullTimeStaffFactory : IStaffFactory
    {
        public StaffBase Create(int id, string name, decimal salary)
            => new FullTimeStaff(id, name, salary);
    }
}
