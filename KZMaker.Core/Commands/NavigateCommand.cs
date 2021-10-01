using KZMaker.Core.Navigation;
using MvvmCross.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.Commands
{
    public class NavigateCommand : IMvxCommand<ViewModelType>
    {
        private readonly INavigator _navigator;

        public NavigateCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public bool CanExecute(ViewModelType parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ViewModelType type = (ViewModelType)parameter;

            _navigator.Navigate(type);
        }

        public void Execute(ViewModelType parameter)
        {
            _navigator.Navigate(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            throw new NotImplementedException();
        }
    }
}
