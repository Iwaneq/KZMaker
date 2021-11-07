using KZMaker.Core.ResourceManagement;
using KZMaker.Core.ViewModels;
using MvvmCross.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.Commands
{
    public class SaveSettingsCommand : IMvxCommand
    {
        private readonly ISettingsService _settingsService;
        private readonly SettingsViewModel _settingsViewModel;

        public SaveSettingsCommand(ISettingsService settingsService, SettingsViewModel settingsViewModel)
        {
            _settingsService = settingsService;
            _settingsViewModel = settingsViewModel;
        }

        public event EventHandler CanExecuteChanged;

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
            SaveSettings();
        }

        public void Execute(object parameter)
        {
            SaveSettings();
        }

        private void SaveSettings()
        {
            //Save AppSettings
            _settingsService.UpdateSettings(_settingsViewModel.SavingPath, _settingsViewModel.ThemeColor);
        }

        public void RaiseCanExecuteChanged()
        {
            throw new NotImplementedException();
        }
    }
}
