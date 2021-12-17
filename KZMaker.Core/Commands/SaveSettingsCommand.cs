using KZMaker.Core.Models;
using KZMaker.Core.ResourceManagement;
using KZMaker.Core.Services.Interfaces;
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
        private readonly INotificationsService _notificationsService;

        public SaveSettingsCommand(ISettingsService settingsService, SettingsViewModel settingsViewModel, INotificationsService notificationsService)
        {
            _settingsService = settingsService;
            _settingsViewModel = settingsViewModel;
            _notificationsService = notificationsService;
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
            //Get settings from ViewModel
            Settings settings = new Settings()
            {
                SavingPath = _settingsViewModel.SavingPath,
                ThemeColor = _settingsViewModel.ThemeColor,
                IsSavingManually = _settingsViewModel.IsSavingManually,
                DefaultZastep = _settingsViewModel.DefaultZastep
            };

            try
            {
                //Save AppSettings
                _settingsService.UpdateSettings(settings);
            }
            catch (Exception ex)
            {
                _notificationsService.UpdateMessage($"Błąd: {ex.Message}", true);
                return;
            }

            _notificationsService.UpdateMessage("Zapisano ustawienia!", false);
        }

        public void RaiseCanExecuteChanged()
        {
            throw new NotImplementedException();
        }
    }
}
