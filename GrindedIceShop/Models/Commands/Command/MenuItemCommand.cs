using GrindedIceShop.Models.Bases;
using GrindedIceShop.Models.Beverages;
using GrindedIceShop.Models.Commands.Actions;

namespace GrindedIceShop.Models.Commands.Command
{
    public class MenuItemCommand : IMyCommand
    {
        private readonly MenuItem _menuItem;
        private readonly PriceAction _priceAction;
        private readonly decimal _amount;

        public bool IsCommandExecuted { get; private set; }

        public MenuItemCommand(Beverage beverage, PriceAction priceAction, decimal amount)
        {
            _menuItem = beverage;
            _priceAction = priceAction;
            _amount = amount;
        }

        public void ExecuteAction()
        {
            if (Equals(_priceAction, PriceAction.Increase))
            {
                _menuItem.IncreasePrice(_amount);
                IsCommandExecuted = true;
            }
            else //if (_priceAction == PriceAction.Decrease)
            {
                _menuItem.DecreasePrice(_amount);
            }
        }

        public void UndoAction()
        {
            if (!IsCommandExecuted)
                return;

            if (Equals(_priceAction, PriceAction.Increase))
            {
                _menuItem.DecreasePrice(_amount);
            }
            else
            {
                _menuItem.IncreasePrice(_amount);
            }
        }
    }
}
