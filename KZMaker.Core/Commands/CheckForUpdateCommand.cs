using KZMaker.Core.Services;
using MvvmCross.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.Commands
{
    class CheckForUpdateCommand : IMvxCommand
    {
        private readonly IUpdateService _updateService;
        public event EventHandler CanExecuteChanged;

        public CheckForUpdateCommand(IUpdateService updateService)
        {
            _updateService = updateService;
        }

        public bool CanExecute()
        {
            return true;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute()
        {
            CheckForUpdate();
        }

        public void Execute(object parameter)
        {
            CheckForUpdate();
        }

        private void CheckForUpdate()
        {
            _updateService.CheckForUpdate();
        }

        public void RaiseCanExecuteChanged()
        {
            throw new NotImplementedException();
        }
    }
}
