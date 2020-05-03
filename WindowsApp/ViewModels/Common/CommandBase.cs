using System;
using System.Windows.Input;

namespace WindowsApp.ViewModels.Common
{
    public class CommandBase : CommandBase<object>
    {
        public CommandBase(Action<object> execute) : base(execute)
        {
        }
    }

    public class CommandBase<T> : ICommand
    {
        private readonly Action<T> _execute;

        public CommandBase(Action<T> execute)
        {
            _execute = execute;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }
    }
}
