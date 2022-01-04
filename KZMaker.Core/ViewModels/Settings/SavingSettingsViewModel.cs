using KZMaker.Core.Exceptions;
using KZMaker.Core.Services;
using KZMaker.Core.Services.Interfaces;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.ViewModels.Settings
{
    public class SavingSettingsViewModel : MvxViewModel
    {
        private readonly IMessageBoxService _messageBoxService;
        private readonly INotificationsService _notificationsService;

        private string _savingPath = AppSettings.Default.SavingPath;
        public string SavingPath
        {
            get { return _savingPath; }
            set
            {
                _savingPath = value;
                RaisePropertyChanged(() => SavingPath);
            }
        }


        private bool _isSavingManually;
        public bool IsSavingManually
        {
            get { return _isSavingManually; }
            set
            {
                _isSavingManually = value;
                RaisePropertyChanged(() => IsSavingManually);
            }
        }


        public IMvxCommand GetSavingPathCommand { get; set; }


        public SavingSettingsViewModel(IMessageBoxService messageBoxService, INotificationsService notificationsService)
        {
            _messageBoxService = messageBoxService;

            GetSavingPathCommand = new MvxCommand(GetSavingPath);
            IsSavingManually = AppSettings.Default.IsSavingManually;
            _notificationsService = notificationsService;
        }


        private void GetSavingPath()
        {
            try
            {
                if (!string.IsNullOrEmpty(SavingPath))
                {
                    SavingPath = _messageBoxService.GetSavingPath(SavingPath);
                }
                else
                {
                    SavingPath = _messageBoxService.GetSavingPath();
                }
            }
            catch (GetPathFailedException)
            {
                _notificationsService.UpdateMessage("Błąd przy wczytaniu ścieżki", true);
            }
        }
    }
}
