using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace BaseProject.Commons.Commands
{
    public class DelegateCommand : ICommand
    {
        protected Action ExecuteMethod { get; set; }
        protected Func<bool> CanExecuteMethod { get; set; }

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            this.ExecuteMethod = executeMethod;
            this.CanExecuteMethod = canExecuteMethod;
        }

        public DelegateCommand(Action executeMethod)
        {
            this.ExecuteMethod = executeMethod;
        }

        protected DelegateCommand()
        { }


        public virtual bool CanExecute()
        {
            if (CanExecuteMethod == null) return true;
            return CanExecuteMethod();
        }

        public virtual void Execute()
        {
            if (ExecuteMethod != null)
            {
                ExecuteMethod();
            }
        }

        public virtual bool CanExecute(object parameter)
        {
            return CanExecute();
        }

        public virtual void Execute(object parameter)
        {
            Execute();
        }

        public void OnCanExecuteChanged()
        {
            if (CanExecuteChanged != null) CanExecuteChanged(this, EventArgs.Empty);
        }

        public void OnCanExecuteChanged(object sender, object eventArgs)
        {
            OnCanExecuteChanged();
        }
    }
}
