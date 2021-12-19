using KZMaker.Core.Commands;
using KZMaker.Core.Exceptions;
using KZMaker.Core.Models;
using KZMaker.Core.ResourceManagement;
using KZMaker.Core.Services;
using KZMaker.Core.Services.Interfaces;
using KZMaker.Core.ViewModels.Progress;
using KZMaker.Core.ViewModels.Settings;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.ViewModels
{
    public class SettingsViewModel : MvxViewModel
    {
        private readonly GeneralSettingsViewModel _generalSettingsViewModel;
        private readonly SavingSettingsViewModel _savingSettingsViewModel;
        private readonly UpdatesSettingsViewModel _updatesSettingsViewModel;
        private readonly InfoSettingsViewModel _infoSettingsViewModel;

        private List<MvxViewModel> _childViewModels;

        public IMvxCommand SaveSettingsCommand { get; set; }
        public IMvxCommand NextViewModelCommand { get; set; }
        public IMvxCommand PreviousViewModelCommand { get; set; }


        public string SavingPath => _savingSettingsViewModel.SavingPath;
        public string ThemeColor => _generalSettingsViewModel.ThemeColor;
        public bool IsSavingManually => _savingSettingsViewModel.IsSavingManually;
        public string DefaultZastep => _generalSettingsViewModel.DefaultZastep;
        public bool IsCheckingUpdatesAtStart => _updatesSettingsViewModel.IsCheckingUpdatesAtStart;


        private MvxViewModel _currentViewModel;
        public MvxViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set 
            {
                _currentViewModel = value;
                RaisePropertyChanged(() => CurrentViewModel);
            }
        }


        private string _childName;
        public string ChildName
        {
            get { return _childName; }
            set 
            {
                _childName = value;
                RaisePropertyChanged(() => ChildName);
            }
        }


        public SettingsViewModel(ISettingsService settingsService, IUpdateService updateService, INotificationsService notificationsService, IMessageBoxService messageBoxService)
        {
            _generalSettingsViewModel = new GeneralSettingsViewModel();
            _savingSettingsViewModel = new SavingSettingsViewModel(messageBoxService);
            _updatesSettingsViewModel = new UpdatesSettingsViewModel(updateService);
            _infoSettingsViewModel = new InfoSettingsViewModel(updateService);

            _childViewModels = new List<MvxViewModel>()
            {
                _generalSettingsViewModel,
                _savingSettingsViewModel,
                _updatesSettingsViewModel,
                _infoSettingsViewModel
            };

            //Set CurrentViewModel (with Settings Title/Child's Name)
            CurrentViewModel = _childViewModels[0];
            UpdateTitle(0);

            NextViewModelCommand = new MvxCommand(NextViewModel);
            PreviousViewModelCommand = new MvxCommand(PreviousViewModel);

            SaveSettingsCommand = new SaveSettingsCommand(settingsService, this, notificationsService);
        }

        private void NextViewModel()
        {
            int viewModelsCount = _childViewModels.Count();
            int currIndex = _childViewModels.FindIndex(x => x == CurrentViewModel);

            //If CurrentViewModel is last in list
            if (CurrentViewModel == _childViewModels[viewModelsCount - 1])
            {
                int newIndex = 0;

                CurrentViewModel = _childViewModels[newIndex];
                UpdateTitle(newIndex);
            }
            else
            {
                int newIndex = currIndex + 1;

                CurrentViewModel = _childViewModels[newIndex];
                UpdateTitle(newIndex);
            }
        }

        private void PreviousViewModel()
        {
            int viewModelsCount = _childViewModels.Count();
            int currIndex = _childViewModels.FindIndex(x => x == CurrentViewModel);

            //If CurrentViewModel is first in list
            if (CurrentViewModel == _childViewModels[0])
            {
                int newIndex = viewModelsCount - 1;

                CurrentViewModel = _childViewModels[newIndex];
                UpdateTitle(newIndex);
            }
            else
            {
                int newIndex = currIndex - 1;
                CurrentViewModel = _childViewModels[newIndex];
                UpdateTitle(newIndex);
            }
        }

        private void UpdateTitle(int currIndex)
        {
            switch (currIndex)
            {
                case 0:
                    ChildName = "Ogólne";
                    break;
                case 1:
                    ChildName = "Zapis";
                    break;
                case 2:
                    ChildName = "Aktualizacje";
                    break;
                case 3:
                    ChildName = "Informacje";
                    break;
            }
        }
    }
}
