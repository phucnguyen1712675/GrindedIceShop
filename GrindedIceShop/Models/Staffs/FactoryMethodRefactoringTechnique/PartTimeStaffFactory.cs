namespace GrindedIceShop.Models.Staffs.FactoryMethodRefactoringTechnique
{
    public class PartTimeStaffFactory : IStaffFactory
    {
        public StaffBase Create(int id, string name, decimal salary)
            => new PartTimeStaff(id, name, salary);
    }
}
