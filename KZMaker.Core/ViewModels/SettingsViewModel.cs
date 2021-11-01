﻿using KZMaker.Core.Commands;
using KZMaker.Core.Models;
using KZMaker.Core.ResourceManagement;
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
        private MvxObservableCollection<ThemeColorOptionModel> _colors = new MvxObservableCollection<ThemeColorOptionModel>()
        {
            new ThemeColorOptionModel()
            {
                ColorName = "Biały",
                ColorValue = "#FFFFFF",
                ThemeColorEnum = ThemeColor.White
            },
            new ThemeColorOptionModel()
            {
                ColorName = "Czarny",
                ColorValue = "#272727",
                ThemeColorEnum = ThemeColor.Black
            },
            new ThemeColorOptionModel()
            {
                ColorName = "Niebieski",
                ColorValue = "#004fcf", 
                ThemeColorEnum = ThemeColor.Blue
            },
            new ThemeColorOptionModel()
            {
                ColorName = "Zielony",
                ColorValue = "#337500"
            },
            new ThemeColorOptionModel()
            {
                ColorName = "Fioletowy",
                ColorValue = "#5D00A8"
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


        public IMvxCommand SaveSettingsCommand { get; set; }

        

        public ThemeColor ThemeColor => SelectedColor.ThemeColorEnum;

        private string _savingPath = App.AppSettings.SavingPath;

        public string SavingPath
        {
            get { return _savingPath; }
            set 
            {
                _savingPath = value;
                RaisePropertyChanged(() => SavingPath);
            }
        }

        public SettingsViewModel(ISettingsService settingsService)
        {
            SaveSettingsCommand = new SaveSettingsCommand(settingsService, this);
        }

    }
}
