using System.Collections.Generic;
using System.Linq;

namespace GrindedIceShop.Models.Commands.MenuItem
{
    public class ModifyPrice
    {
        private readonly List<IMyCommand> _commands;
        private IMyCommand _command;

        public ModifyPrice()
        {
            _commands = new List<IMyCommand>();
        }

        public void SetCommand(IMyCommand command) => _command = command;

        public void Invoke()
        {
            _commands.Add(_command);
            _command.ExecuteAction();
        }

        public void UndoActions()
        {
            foreach (var command in Enumerable.Reverse(_commands))
            {
                command.UndoAction();
            }
        }
    }
}
