using KZMaker.Core.Services;
using KZMaker.Core.ViewModels;
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
        private readonly SettingsViewModel _viewModel;
        public event EventHandler CanExecuteChanged;

        public CheckForUpdateCommand(IUpdateService updateService, SettingsViewModel viewModel)
        {
            _updateService = updateService;
            _viewModel = viewModel;
        }

        public bool CanExecute()
        {
            return true;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute()
        {
            await CheckForUpdate();
        }

        public async void Execute(object parameter)
        {
            await CheckForUpdate();
        }

        private async Task CheckForUpdate()
        {
            await _updateService.CheckForUpdate(false);

            _viewModel.UpdateVersionText();
        }

        public void RaiseCanExecuteChanged()
        {
            throw new NotImplementedException();
        }
    }
}
