namespace GrindedIceShop.Models.Staffs.FactoryMethodRefactoringTechnique
{
    public interface IStaffFactory
    {
        StaffBase Create(int id, string name, decimal salary);
    }
}
