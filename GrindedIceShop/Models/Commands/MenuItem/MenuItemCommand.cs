using GrindedIceShop.Models.Beverages;

namespace GrindedIceShop.Models.Commands.MenuItem
{
    public class MenuItemCommand : IMyCommand
    {
        private readonly Beverage _beverage;
        private readonly PriceAction _priceAction;
        private readonly decimal _amount;

        public bool IsCommandExecuted { get; private set; }

        public MenuItemCommand(Beverage beverage, PriceAction priceAction, decimal amount)
        {
            _beverage = beverage;
            _priceAction = priceAction;
            _amount = amount;
        }

        public void ExecuteAction()
        {
            if (_priceAction == PriceAction.Increase)
            {
                _beverage.IncreasePrice(_amount);
                IsCommandExecuted = true;
            }
            else if (_priceAction == PriceAction.Decrease)
            {
                _beverage.DecreasePrice(_amount);
            }
        }

        public void UndoAction()
        {
            if (!IsCommandExecuted)
                return;

            if (_priceAction == PriceAction.Increase)
            {
                _beverage.DecreasePrice(_amount);
            }
            else
            {
                _beverage.IncreasePrice(_amount);
            }
        }
    }
}
