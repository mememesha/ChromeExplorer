using System;
using System.Windows.Input;

namespace MikeV.WindowGoogleChrome.Wpf
{
    internal class DelegateCommand : ICommand
    {
        private Action<object> _execute = null;
        private Predicate<object> _canExecute = null;

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action<object> execute = null, Predicate<object> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public virtual void NotifyCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            _execute?.Invoke(parameter);
        }
    }
}