﻿using KZMaker.Core.Commands;
using KZMaker.Core.Exceptions;
using KZMaker.Core.Models;
using KZMaker.Core.ResourceManagement;
using KZMaker.Core.Services;
using KZMaker.Core.Services.Interfaces;
using KZMaker.Core.ViewModels.Progress;
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
        private readonly IUpdateService _updateService;
        private readonly IMessageBoxService _messageBoxService;

        private MvxObservableCollection<ThemeColorOptionModel> _colors = new MvxObservableCollection<ThemeColorOptionModel>()
        {
            new ThemeColorOptionModel()
            {
                ColorName = "Biały",
                ColorValue = "#FFFFFF",
                ThemeColor = "Light"
            },
            new ThemeColorOptionModel()
            {
                ColorName = "Czarny",
                ColorValue = "#272727",
                ThemeColor = "Dark"
            },
            new ThemeColorOptionModel()
            {
                ColorName = "Niebieski",
                ColorValue = "#004fcf", 
                ThemeColor = "Blue"
            },
            new ThemeColorOptionModel()
            {
                ColorName = "Zielony",
                ColorValue = "#337500",
                ThemeColor = "Green"
            },
            new ThemeColorOptionModel()
            {
                ColorName = "Fioletowy",
                ColorValue = "#5D00A8",
                ThemeColor = "Purple"
            }
        };

        public MvxObservableCollection<ThemeColorOptionModel> Colors
        {
            get { return _colors; }
            set 
            {
                _colors = value;
                RaisePropertyChanged(() => Colors);
            }
        }

        private ThemeColorOptionModel _selectedColor;

        public ThemeColorOptionModel SelectedColor
        {
            get { return _selectedColor; }
            set 
            {
                _selectedColor = value;
                RaisePropertyChanged(() => SelectedColor);
                RaisePropertyChanged(() => ThemeColor);
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



        public IMvxCommand SaveSettingsCommand { get; set; }
        public IMvxCommand GetSavingPathCommand { get; set; }
        public IMvxCommand CheckForUpdateCommand { get; set; }



        public string ThemeColor => SelectedColor.ThemeColor;

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

        private string _defaultZastep = AppSettings.Default.DefaultZastep;

        public string DefaultZastep
        {
            get { return _defaultZastep; }
            set 
            {
                _defaultZastep = value;
                RaisePropertyChanged(() => DefaultZastep);
            }
        }

        private string _version;

        public string Version
        {
            get { return _version; }
            set { _version = value; }
        }


        public SettingsViewModel(ISettingsService settingsService, IMessageBoxService messageBoxService, IUpdateService updateService, INotificationsService notificationsService)
        {
            SaveSettingsCommand = new SaveSettingsCommand(settingsService, this, notificationsService);
            GetSavingPathCommand = new MvxCommand(GetSavingPath);
            CheckForUpdateCommand = new CheckForUpdateCommand(updateService, this);

            _messageBoxService = messageBoxService;
            _updateService = updateService;

            SelectedColor = Colors.Where(x => x.ThemeColor == AppSettings.Default.Theme).FirstOrDefault();
            IsSavingManually = AppSettings.Default.IsSavingManually;
            Version = _updateService.GetCurrentVersion();
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
                SavingPath = "Błąd przy wczytaniu ścieżki";
            }
        }

        public void UpdateVersionText()
        {
            Version = _updateService.GetCurrentVersion();
        }
    }
}
