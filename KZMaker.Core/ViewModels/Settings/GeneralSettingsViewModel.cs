using KZMaker.Core.Models;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZMaker.Core.ViewModels.Settings
{
    public class GeneralSettingsViewModel : MvxViewModel
    {
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


        public string ThemeColor => SelectedColor.ThemeColor;


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


        public GeneralSettingsViewModel()
        {
            SelectedColor = Colors.Where(x => x.ThemeColor == AppSettings.Default.Theme).FirstOrDefault();
        }
    }
}
