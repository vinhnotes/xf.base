using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace BaseProject.Commons.Commands
{
    public class RelayCommand : ICommand
    {
        // Fields 
        #region Fields
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;
        #endregion

        // Constructors 
        #region Constructors
        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {

        }
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null) throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }
        #endregion

        //Members
        #region ICommand Members [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }
        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public void OnCanExecuteChanged()
        {
            if (CanExecuteChanged != null) CanExecuteChanged(this, EventArgs.Empty);
        }

        public void OnCanExecuteChanged(object sender, object eventArgs)
        {
            OnCanExecuteChanged();
        }
        #endregion // ICommand Members
    }
}