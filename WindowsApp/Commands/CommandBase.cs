using System;
using System.Windows.Input;

namespace WindowsApp.Commands
{
    public class CommandBase<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Predicate<T> _canExecute;

        public CommandBase(Action<T> execute, Predicate<T> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute ?? (o => true);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute.Invoke((T)parameter);
        }
    }
}
