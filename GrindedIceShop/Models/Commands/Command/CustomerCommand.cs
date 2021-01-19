using GrindedIceShop.Models.Commands.Actions;
using GrindedIceShop.Models.Customers;

namespace GrindedIceShop.Models.Commands.Command
{
    public class CustomerCommand : IMyCommand
    {
        private readonly Customer _customer;
        private readonly PointAction _pointAction;
        private readonly int _amount;

        public bool IsCommandExecuted { get; private set; }

        public CustomerCommand(Customer customer, PointAction pointAction, int amount)
        {
            _customer = customer;
            _pointAction = pointAction;
            _amount = amount;
        }

        public void ExecuteAction()
        {
            if (Equals(_pointAction, PointAction.Increase))
            {
                _customer.IncreasePoint(_amount);
                IsCommandExecuted = true;
            }
            else //if (_pointAction == PointAction.Decrease)
            {
                _customer.DecreasePoint(_amount);
            }
        }

        public void UndoAction()
        {
            if (!IsCommandExecuted)
                return;

            if (Equals(_pointAction, PointAction.Increase))
            {
                _customer.DecreasePoint(_amount);
            }
            else
            {
                _customer.IncreasePoint(_amount);
            }
        }
    }
}
