namespace GrindedIceShop.Models.Commands
{
    public interface IMyCommand
    {
        void ExecuteAction();
        void UndoAction();
    }
}
